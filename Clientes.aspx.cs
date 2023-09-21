using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlPagosFacturas
{
    public partial class Clientes : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarClientes();
            }
        }
        DataClassesEXAMENDataContext bd = new DataClassesEXAMENDataContext();
        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                string dpi = Txtdpi.Text;
                string nombres = TxtClienteNombre.Text;
                string direccion = TxtClienteDireccion.Text; 
                string telefono = TxtClienteTelefono.Text;
                decimal limiteCredito = decimal.Parse(TxtClienteSaldo.Text);


                var cli = new clientes
                {
                    Dpi = dpi,
                    nombres = nombres,
                    direccion = direccion, 
                    telefono = telefono,
                    limiteCredito = limiteCredito
                };

                bd.clientes.InsertOnSubmit(cli);
                bd.SubmitChanges();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('CLIENTE AÑADIDO');", true);

                cargarClientes();
                limpiarForm();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('" + ex.Message.ToString() + "');", true);
            }
        }
        void cargarClientes()
        {
            var query = from clientes in bd.clientes select clientes;
            VistaClientes.DataSource = query;
            VistaClientes.DataBind();
        }
        void limpiarForm()
        {
            this.Txtdpi.Text = "";
            this.TxtClienteNombre.Text = "";
            this.TxtClienteDireccion.Text = "";
            this.TxtClienteTelefono.Text = "";
            this.TxtClienteSaldo.Text = "";
        }
        protected void chk_buttonCheck(object sender, EventArgs e)
        {
            int rowind = ((GridViewRow)(sender as Control).NamingContainer).RowIndex;
            CheckBox cd = (CheckBox)VistaClientes.Rows[rowind].FindControl("chk");
            if (cd.Checked == true)
            {
                this.BtnUpdate.Visible = true;
                this.BtnDelete.Visible = true;
                this.BtnCreate.Visible = false;
                id.Value = VistaClientes.Rows[rowind].Cells[1].Text;
                Txtdpi.Text = VistaClientes.Rows[rowind].Cells[2].Text;
                TxtClienteNombre.Text = VistaClientes.Rows[rowind].Cells[3].Text;
                TxtClienteDireccion.Text = VistaClientes.Rows[rowind].Cells[4].Text;
                TxtClienteTelefono.Text = VistaClientes.Rows[rowind].Cells[5].Text;
                TxtClienteSaldo.Text = VistaClientes.Rows[rowind].Cells[6].Text;
            }
            else
            {
                this.BtnUpdate.Visible = false;
                this.BtnDelete.Visible = false;
                this.BtnCreate.Visible = true;
                this.Txtdpi.Enabled = true;
                this.Txtdpi.Text = "";
                this.TxtClienteNombre.Text = "";
                this.TxtClienteDireccion.Text = "";
                this.TxtClienteSaldo.Text = "";
                Txtdpi.Focus();
            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse( this.id.Value);
                string dpi = Txtdpi.Text;
                string nombres = TxtClienteNombre.Text;
                string direccion = TxtClienteDireccion.Text;
                string telefono = TxtClienteTelefono.Text;
                decimal limiteCredito = decimal.Parse(TxtClienteSaldo.Text);

                var stupdate = (from cliente in bd.clientes where cliente.id == id select cliente).First();
                stupdate.Dpi = dpi;
                stupdate.nombres = nombres;
                stupdate.direccion = direccion;
                stupdate.telefono = telefono;
                stupdate.limiteCredito = limiteCredito;
                bd.SubmitChanges();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Cliente Actualizado');", true);

                cargarClientes();
                this.BtnUpdate.Visible = false;
                this.BtnDelete.Visible = false;
                this.BtnCreate.Visible = true;
                limpiarForm();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('" + ex.Message.ToString() + "');", true);
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(this.id.Value);


                var stEliminar = (from clien in bd.clientes where clien.id == id select clien).First();
                bd.clientes.DeleteOnSubmit(stEliminar);
                bd.SubmitChanges();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('Cliente Eliminado');", true);

                cargarClientes();
                this.BtnUpdate.Visible = false;
                this.BtnDelete.Visible = false;
                this.BtnCreate.Visible = true;
                limpiarForm();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Script", "alert('" + ex.Message.ToString() + "');", true);
            }
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            if (Txtdpi.Text != string.Empty)
            {
                var cliBuscar = from clien in bd.clientes where clien.Dpi == Txtdpi.Text select clien;
                VistaClientes.DataSource = cliBuscar;
                VistaClientes.DataBind();
            }
            else
            {
                cargarClientes();
            }
        }
    }
}