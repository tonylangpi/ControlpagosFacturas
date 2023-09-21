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
            // Obtenemos los pagos realizados por mes
            var pagosPorMes = bd.Venta.Where(x => x.cliente == Cliente && x.EstadoFactura == "PAGADA" && x.TipoFactura == "CREDITO").GroupBy(p => p.Mes).Select(g => new
            {
                Mes = g.Key,
                Monto = g.Sum(p => p.monto)
            });
            // Obtenemos los pagos realizados por mes
            var pagosPorMesPendientes = bd.Venta.Where(x => x.cliente == Cliente && x.EstadoFactura == "NO PAGADA" && x.TipoFactura == "CREDITO").GroupBy(p => p.Mes).Select(g => new
            {
                Mes = g.Key,
                Monto = g.Sum(p => p.monto)
            });
            this.SaldoPagado.Text = "Q. " + saldoPagado.ToString();
            this.SaldoPendiente.Text = "Q. " + saldoNoPagado.ToString();
            if(pagosPorMes.Count() > 0)
            {
                VistaConsulta.DataSource = pagosPorMes;
                VistaConsulta.DataBind();
            }
            else
            {

                VistaConsulta.DataSource = "";
            }
            if (pagosPorMesPendientes.Count() > 0)
            {
                VistaPendientes.DataSource = pagosPorMesPendientes;
                VistaPendientes.DataBind();
            }
            else
            {
                VistaPendientes.DataSource = "";
            }
        }
    }
}