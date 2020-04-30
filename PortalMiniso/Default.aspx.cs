using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortalMiniso
{
    public partial class _Default : Page
    {
        private string user = string.Empty;
        private string pass = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["sesion"] == null || Session["sesion"].ToString().Equals("SinAcceso"))
            {
            }
            else
            {
                Response.Redirect("Registro.aspx");
            }
        }
       
        protected void TextBoxUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ButtonIngresar_Click(object sender, EventArgs e)
        {
            user = TextBoxUsuario.Text;
            pass = TextBoxContraseña.Text;

            Connections connections = new Connections();
            string response = connections.ejecutarQuery(user);

            if(response == user && response == pass)
            {
                Session["sesion"] = "ConAcceso";
                Response.Redirect("Registro.aspx");
            }
            else
            {

                Session["sesion"] = "SinAcceso";
                Label lbl = new Label();
                lbl.Text = "Usuario o contraseña incorrectos";
                lbl.CssClass = "text text-center  text-danger ";
                Div_Validacion.Controls.Add(lbl);
                
            }
        }
    }
}