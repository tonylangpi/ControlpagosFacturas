using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlPagosFacturas
{
    public partial class Facturas : Page
    {
        DataClassesEXAMENDataContext bd = new DataClassesEXAMENDataContext();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarVentas();
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

        protected void BtnEvaluar_Click(object sender, EventArgs e)
        {
            int idCliente = int.Parse(CLIENT_ID.SelectedValue);
            string tipoFactura = TipoFact.SelectedValue;
            if(tipoFactura == "CREDITO")
            {
                var saldoPermitido = (from cliente in bd.clientes where cliente.id == idCliente select cliente).First();
                if (decimal.Parse(TxtMontoFact.Text) > saldoPermitido.limiteCredito)
                {
                    BtnCreate.Visible = false;
                    this.mensajeServer.Text = "El credito permitido se excedio, el credito es: " + saldoPermitido.limiteCredito.ToString();
                }
                else
                {
                    BtnCreate.Visible = true;
                    this.mensajeServer.Text = ""; 
                }
            }
            else
            {
                BtnCreate.Visible = true;
            }
            
        }

        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            string SerieFactura = TxtSeriefact.Text.Trim();
            int Mes = int.Parse(this.Mes.SelectedValue);
            decimal Monto = decimal.Parse(TxtMontoFact.Text);
            string Tipofactu = TipoFact.SelectedValue;
            int ClientId = int.Parse(CLIENT_ID.SelectedValue);
            var Dates = DateTime.Now;
            string estado = ""; 
            if(Tipofactu == "CREDITO")
            {
                estado = "NO PAGADA";
            }
            else
            {
                estado = "PAGADA";
            }


            var vent = new Venta
            {
                SerieFactura = SerieFactura,
                Fecha = Dates,
                Mes = Mes,
                monto = Monto,
                TipoFactura = Tipofactu,
                EstadoFactura = estado,
                cliente = ClientId
            };

            bd.Venta.InsertOnSubmit(vent);
            bd.SubmitChanges();
            if (Tipofactu == "CREDITO")
            {
                /*Actualizamos el saldo maximo permitdo del cliente*/
                var saldoPermitido = (from cliente in bd.clientes where cliente.id == ClientId select cliente).First();
                var SaldoFinal = saldoPermitido.limiteCredito - Monto;
                saldoPermitido.limiteCredito = SaldoFinal;
                bd.SubmitChanges();
                
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Venta CREADA');", true);
            cargarVentas();
            limpiarForm();

        }
        protected void chk_buttonCheck(object sender, EventArgs e)
        {
            int rowind = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            CheckBox cd = (CheckBox)VistaVentas.Rows[rowind].FindControl("chk");
            if (cd.Checked == true)
            {
                this.BtnUpdate.Visible = true;
                this.BtnCreate.Visible = false;
                this.BtnEvaluar.Visible = false;
                this.mensajeServer.Text = ""; 
                IdFactura.Value = VistaVentas.Rows[rowind].Cells[1].Text;
                EstadoFactura.Value = VistaVentas.Rows[rowind].Cells[6].Text;
                TxtSeriefact.Text = VistaVentas.Rows[rowind].Cells[2].Text;
                CLIENT_ID.SelectedValue = VistaVentas.Rows[rowind].Cells[9].Text;
                Mes.SelectedValue = VistaVentas.Rows[rowind].Cells[8].Text;
                TxtMontoFact.Text = VistaVentas.Rows[rowind].Cells[7].Text;
                TipoFact.SelectedValue = VistaVentas.Rows[rowind].Cells[5].Text;
            }
            else
            {
                this.BtnUpdate.Visible = false;
                this.BtnEvaluar.Visible = true; 
                this.TxtSeriefact.Text = "";
                this.TxtMontoFact.Text = "";
                IdFactura.Value = ""; 
                TxtSeriefact.Focus();
            }
        }
        void cargarVentas()
        {
            //var query = from ventas in bd.Venta select ventas;
            var innerJoinQuery =
             from ventas in bd.Venta
             join clientes in bd.clientes on ventas.cliente equals clientes.id
             select new { VentID = ventas.id, SerieFactura = ventas.SerieFactura, Dpi = clientes.Dpi, NombreCliente = clientes.nombres, TipoPago = ventas.TipoFactura, Estado = ventas.EstadoFactura, Monto = ventas.monto, Mes = ventas.Mes, idCliente = clientes.id };

            VistaVentas.DataSource = innerJoinQuery;
            VistaVentas.DataBind();
        }
        void limpiarForm()
        {
            this.TxtSeriefact.Text = "";
            this.TxtMontoFact.Text = "";
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int idVenta = int.Parse(this.IdFactura.Value);
                string Estado = this.EstadoFactura.Value; 
                string SerieFactura = TxtSeriefact.Text.Trim();
                int Mes = int.Parse(this.Mes.SelectedValue);
                decimal Monto = decimal.Parse(TxtMontoFact.Text);
                string Tipofactu = TipoFact.SelectedValue;
                int ClientId = int.Parse(CLIENT_ID.SelectedValue);
                if (Tipofactu == "CREDITO" && Estado != "PAGADA")
                {
                    var stupdate = (from vent in bd.Venta where vent.id == idVenta select vent).First();
                    stupdate.EstadoFactura = "PAGADA";
                    bd.SubmitChanges();
                    /*Actualizamos el saldo maximo permitdo del cliente*/
                    var saldoPermitido = (from cliente in bd.clientes where cliente.id == ClientId select cliente).First();
                    var SaldoFinal = saldoPermitido.limiteCredito + Monto;
                    saldoPermitido.limiteCredito = SaldoFinal;
                    bd.SubmitChanges();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Venta Pagada');", true);

                    cargarVentas();
                    this.BtnUpdate.Visible = false;
                    this.BtnCreate.Visible = false;
                    limpiarForm();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('No puedes pagar una venta ya pagada XD');", true);

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('" + ex.Message.ToString() + "');", true);
            }

        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {

            if (TxtSeriefact.Text != string.Empty)
            {
            
                var venBuscar =
            from ventas in bd.Venta
            join clientes in bd.clientes on ventas.cliente equals clientes.id
            where ventas.SerieFactura == TxtSeriefact.Text
            select new { VentID = ventas.id, SerieFactura = ventas.SerieFactura, Dpi = clientes.Dpi, NombreCliente = clientes.nombres, TipoPago = ventas.TipoFactura, Estado = ventas.EstadoFactura, Monto = ventas.monto, Mes = ventas.Mes, idCliente = clientes.id };

                VistaVentas.DataSource = venBuscar;
                VistaVentas.DataBind();
            }
            else
            {
                cargarVentas();
            }
        }
    }
}