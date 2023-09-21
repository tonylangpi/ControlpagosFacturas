using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlPagosFacturas
{
    public partial class _Default : Page
    {
        DataClassesEXAMENDataContext bd = new DataClassesEXAMENDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Realiza la consulta LINQ para obtener los datos
                var clientes = from cliente in bd.clientes
                               select new
                               {
                                   ID = cliente.id,
                                   Nombre = cliente.nombres,
                                   LimiteCredito = cliente.limiteCredito
                               };

                // Asigna los datos al DropDownList
                CLIENT_ID.DataSource = clientes;
                CLIENT_ID.DataTextField = "Nombre"; // Nombre del campo a mostrar
                CLIENT_ID.DataValueField = "ID";   // Nombre del campo de valor
                CLIENT_ID.DataBind();
            }
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
           int Cliente = int.Parse(this.CLIENT_ID.SelectedValue); 
            // El saldo de lo que esta pagado y estaba al credito
            var saldoPagado = bd.Venta.Where(p => p.EstadoFactura == "PAGADA" && p.TipoFactura == "CREDITO" && p.cliente == Cliente).Sum(p => p.monto);
            //El saldo de lo que no se ha pagado y  esta al credito
            var saldoNoPagado = bd.Venta.Where(a => a.EstadoFactura == "NO PAGADA" && a.TipoFactura == "CREDITO" && a.cliente == Cliente).Sum(Pa => Pa.monto);
            //saldo de credito del cliente aun disponible
            var saldoDisponible = bd.clientes.Where(m => m.id == Cliente).Select(p => p.limiteCredito).First();
            //inner join de facturas venta a tabla de mes
            var facturasMes = from ventas in bd.Venta
                              join meses in bd.MES on ventas.Mes equals meses.id
                              select new { ventas.EstadoFactura, ventas.TipoFactura, Mes = meses.descripcion, ventas.monto, ventas.cliente, ventas.SerieFactura };
            // Obtenemos los pagos ya realizados por mes
            var pagosPorMes = facturasMes.Where(p => p.EstadoFactura == "PAGADA" && p.TipoFactura == "CREDITO" && p.cliente == Cliente).Select(f => new
            {
                SerieFatura = f.SerieFactura,
                Mes = f.Mes,
                Monto = f.monto
            }); 
            // Obtenemos los pagos aun no realizados por mes
            var pagosSinRealizar = facturasMes.Where(p => p.EstadoFactura == "NO PAGADA" && p.TipoFactura == "CREDITO" && p.cliente == Cliente).Select(f => new
            {
                SerieFatura = f.SerieFactura,
                Mes = f.Mes,
                Monto = f.monto
            });
            this.SaldoPagado.Text = "Q. " + saldoPagado.ToString();
            this.SaldoPendiente.Text = "Q. " + saldoNoPagado.ToString();
            this.saldoDisponible.Text = "Q. " + saldoDisponible.ToString();
            if (pagosPorMes.Count() > 0)
            {
                VistaConsulta.DataSource = pagosPorMes;
                VistaConsulta.DataBind();
            }
            else
            {

                VistaConsulta.DataSource = "";
            }
            if (pagosSinRealizar.Count() > 0)
            {
                VistaPendientes.DataSource = pagosSinRealizar;
                VistaPendientes.DataBind();
            }
            else
            {
                VistaPendientes.DataSource = "";
            }
        }
    }
}