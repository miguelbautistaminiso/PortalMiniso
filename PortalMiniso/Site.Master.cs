using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortalMiniso
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["sesion"] == null || Session["sesion"].ToString().Equals("SinAcceso"))
            {
                ButtonCerrar.Visible = false;
            }
            else
            {
                ButtonCerrar.Visible = true;
            }
        }

        protected void ButtonCerrar_Click(object sender, EventArgs e)
        {
            Session["sesion"] = "SinAcceso";

            Response.Redirect("Default.aspx");
        }

    }
}