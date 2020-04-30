using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace PortalMiniso.Model
{
    [Serializable]
    public class BoxesArticulos
    {

        public string numArt { get; set; }
        public string descArt { get; set; }
        public string codArt { get; set; }
        public string precioArt { get; set; }

    }

    public class BoxArticulo
    {
        public TextBox boxNumArt { get; set; }
        public TextBox boxDescArt { get; set; }
        public TextBox boxCodArt { get; set; }
        public TextBox boxPrecioArt { get; set; }
    }
}

