using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ControlPagosFacturas
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        DataClassesEXAMENDataContext conn = new DataClassesEXAMENDataContext();
        protected void ingresar_Click(object sender, EventArgs e)
        {
            var usuario = from user in conn.Usuarios where user.correo == txtcorreo.Text && user.clave == txtclave.Text select user;
            if (usuario.Count() > 0)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                Label1.Text = "Credenciales invalidas"; 
            }
        }
    }
}