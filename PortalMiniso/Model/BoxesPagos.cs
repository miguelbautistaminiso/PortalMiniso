using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace PortalMiniso.Model
{
    [Serializable]
    public class BoxesPagos
    {
        public string numPag { get; set; }
        public string formPag { get; set; }
        public string folPag { get; set; }
        public string impPag { get; set; }

    }

    public class BoxPago
    {
        public TextBox boxNumPag { get; set; }
        public DropDownList boxFormPag { get; set; }
        public TextBox boxFolPag { get; set; }
        public TextBox boxImpPag { get; set; }
    }
}