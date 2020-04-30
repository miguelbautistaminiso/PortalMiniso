using PortalMiniso.Entity;
using PortalMiniso.Model;
using PortalMiniso.util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;

namespace PortalMiniso
{
    public partial class Registro : System.Web.UI.Page
    {

        private Utils utils = new Utils();


        private int contArticulos = 0;
        private int contPagos = 0;

        //Articulos
        private List<BoxesArticulos> listadoArts = new List<BoxesArticulos>();
        private BoxArticulo boxesIniArt;

        //FormasPago
        private List<BoxesPagos> listadoPagos = new List<BoxesPagos>();
        private BoxPago boxesIniPag;

        protected void Page_PreLoad(object sender, EventArgs e)
        {


            if (Session["sesion"] == null || Session["sesion"].ToString().Equals("SinAcceso"))
            {
                Session["sesion"] = "0";
                Response.Redirect("Default.aspx");
            }

            if (ViewState["listadoArts"] != null)
            {
                listadoArts = (List<BoxesArticulos>)ViewState["listadoArts"];

                ButtonArticulos.Visible = true;
                if (listadoArts.Count > 0)
                {
                    ButtonPagos.Visible = true;
                    if (ViewState["listadoPagos"] != null)
                    {
                        listadoPagos = (List<BoxesPagos>)ViewState["listadoPagos"];
                    }

                    if (listadoPagos.Count > 0)
                    {

                        ButtonGuardar.Visible = false;
                    }
                }
                else
                {
                    ButtonPagos.Visible = false;
                    ButtonGuardar.Visible = false;
                }
            }
            else
            {

                ButtonPagos.Visible = false;
                ButtonGuardar.Visible = false;
            }




        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /*
                boxesIniArt = utils.crearBoxesIniArt("0", contArticulos.ToString());
                numArticulo.Controls.Add(boxesIniArt.boxNumArt);
                descArticulo.Controls.Add(boxesIniArt.boxDescArt);
                codBarras.Controls.Add(boxesIniArt.boxCodArt);
                precio.Controls.Add(boxesIniArt.boxPrecioArt);
                ViewState["conteoArt"] = contArticulos.ToString();

                boxesIniPag = utils.crearBoxesIniPag("0", contPagos.ToString());
                numPago.Controls.Add(boxesIniPag.boxNumPag);
                formPago.Controls.Add(boxesIniPag.boxFormPag);
                folPago.Controls.Add(boxesIniPag.boxFolPag);
                impPago.Controls.Add(boxesIniPag.boxImpPag);
                ViewState["conteoPag"] = contPagos.ToString();
                */

                ViewState["conteoArt"] = contArticulos.ToString();

                ViewState["conteoPag"] = contPagos.ToString();
            }
        }



        //Seccion Articulos
        protected void agregarArticulo(object sender, EventArgs e)
        {

            if (!validarGeneral())
            {
                mostrarBoxesArticulos();
                mostrarBoxesPagos();
                return;
            }

            ButtonPagos.Visible = true;

            generalesLectura();
            contArticulos = Int32.Parse(ViewState["conteoArt"].ToString());

            contArticulos = contArticulos + 1;


            if (listadoArts.Count > 0)
            {
                if (agregarDatosArts())
                {

                    mostrarBoxesArticulos();

                    boxesIniArt = utils.crearBoxesIniArt(listadoArts.Count.ToString(), contArticulos.ToString());
                    BoxesArticulos boxesArts = new BoxesArticulos();
                    numArticulo.Controls.Add(boxesIniArt.boxNumArt);
                    descArticulo.Controls.Add(boxesIniArt.boxDescArt);
                    codBarras.Controls.Add(boxesIniArt.boxCodArt);
                    precio.Controls.Add(boxesIniArt.boxPrecioArt);
                    listadoArts.Add(boxesArts);
                    ViewState["conteoArt"] = contArticulos.ToString();
                    ViewState["listadoArts"] = listadoArts;
                }
                else
                {
                    mostrarBoxesArticulos();
                    validarArts();
                }
            }
            else
            {
                BoxesArticulos boxesArts = new BoxesArticulos();
                boxesIniArt = utils.crearBoxesIniArt("0", contArticulos.ToString());
                numArticulo.Controls.Add(boxesIniArt.boxNumArt);
                descArticulo.Controls.Add(boxesIniArt.boxDescArt);
                codBarras.Controls.Add(boxesIniArt.boxCodArt);
                precio.Controls.Add(boxesIniArt.boxPrecioArt);

                listadoArts.Add(boxesArts);
                ViewState["listadoArts"] = listadoArts;
                ViewState["conteoArt"] = contArticulos.ToString();
            }



        }
        protected Boolean agregarDatosArts()
        {

            Boolean artsValidados = true;
            BoxesArticulos boxesArts = new BoxesArticulos();

            var textboxValues = new List<string>();
            if (Request.Form.HasKeys() && listadoArts.Count > 0)
            {
                string key = string.Empty;
                string contador = (listadoArts.Count - 1).ToString();

                key = Request.Form.AllKeys.Where(i => i.Contains((contador + "_Art_Num"))).FirstOrDefault();
                //boxesArts.numArt = Request.Form[key];
                listadoArts[(listadoArts.Count - 1)].numArt = Request.Form[key];

                key = Request.Form.AllKeys.Where(i => i.Contains((contador + "_Art_Cod"))).FirstOrDefault();
                //boxesArts.codArt = Request.Form[key];
                listadoArts[(listadoArts.Count - 1)].codArt = Request.Form[key];

                key = Request.Form.AllKeys.Where(i => i.Contains((contador + "_Art_Des"))).FirstOrDefault();
                //boxesArts.descArt = Request.Form[key];
                listadoArts[(listadoArts.Count - 1)].descArt = Request.Form[key];

                key = Request.Form.AllKeys.Where(i => i.Contains((contador + "_Art_Pre"))).FirstOrDefault();
                //boxesArts.precioArt = Request.Form[key];
                listadoArts[(listadoArts.Count - 1)].precioArt = Request.Form[key];


                if (listadoArts[(listadoArts.Count - 1)].codArt == "" || listadoArts[(listadoArts.Count - 1)].precioArt == "" || listadoArts[(listadoArts.Count - 1)].codArt == null || listadoArts[(listadoArts.Count - 1)].precioArt == null)
                {
                    artsValidados = false;
                }
            }
            return artsValidados;
        }
        public void mostrarBoxesArticulos()
        {
            int conteoArt = 0;

            if (agregarDatosArts())
            {
                foreach (var box in listadoArts)
                {
                    boxesIniArt = utils.crearBoxesArt(box, conteoArt.ToString());
                    numArticulo.Controls.Add(boxesIniArt.boxNumArt);
                    descArticulo.Controls.Add(boxesIniArt.boxDescArt);
                    codBarras.Controls.Add(boxesIniArt.boxCodArt);
                    precio.Controls.Add(boxesIniArt.boxPrecioArt);
                    conteoArt++;

                }

            }
            else
            {
                boxesIniArt = utils.crearBoxesIniArt(conteoArt.ToString(), listadoArts.Count.ToString());
                numArticulo.Controls.Add(boxesIniArt.boxNumArt);
                descArticulo.Controls.Add(boxesIniArt.boxDescArt);
                codBarras.Controls.Add(boxesIniArt.boxCodArt);
                precio.Controls.Add(boxesIniArt.boxPrecioArt);
                conteoArt++;
            }
        }


        //Seccion Pagos
        protected void agregarPagos(object sender, EventArgs e)
        {

            ButtonGuardar.Visible = true;

            if (!validarGeneral())
            {

                mostrarBoxesArticulos();
                mostrarBoxesPagos();
                return;

            }

            if (!validarArts())
            {

                mostrarBoxesArticulos();
                mostrarBoxesPagos();
                return;

            }

            ButtonArticulos.Visible = false;

            mostrarBoxesArticulos();
            generalesLectura();

            contPagos = Int32.Parse(ViewState["conteoPag"].ToString());

            contPagos = contPagos + 1;


            if (listadoPagos.Count > 0)
            {
                if (agregarDatosPago())
                {

                    mostrarBoxesPagos();

                    boxesIniPag = utils.crearBoxesIniPag(listadoPagos.Count.ToString(), contPagos.ToString());
                    BoxesPagos boxesPagos = new BoxesPagos();
                    numPago.Controls.Add(boxesIniPag.boxNumPag);
                    formPago.Controls.Add(boxesIniPag.boxFormPag);
                    folPago.Controls.Add(boxesIniPag.boxFolPag);
                    impPago.Controls.Add(boxesIniPag.boxImpPag);
                    listadoPagos.Add(boxesPagos);
                    ViewState["conteoPag"] = contPagos.ToString();
                    ViewState["listadoPagos"] = listadoPagos;
                }
                else
                {
                    mostrarBoxesPagos();
                    validarPagos();
                }
            }
            else
            {
                BoxesPagos boxesPagos = new BoxesPagos();
                boxesIniPag = utils.crearBoxesIniPag("0", contPagos.ToString());
                numPago.Controls.Add(boxesIniPag.boxNumPag);
                formPago.Controls.Add(boxesIniPag.boxFormPag);
                folPago.Controls.Add(boxesIniPag.boxFolPag);
                impPago.Controls.Add(boxesIniPag.boxImpPag);

                listadoPagos.Add(boxesPagos);
                ViewState["listadoPagos"] = listadoPagos;
                ViewState["conteoPag"] = contPagos.ToString();
            }



        }
        public void mostrarBoxesPagos()
        {

            int conteoPag = 0;

            if (agregarDatosPago())
            {
                foreach (var box in listadoPagos)
                {
                    boxesIniPag = utils.crearBoxesPag(box, conteoPag.ToString());
                    numPago.Controls.Add(boxesIniPag.boxNumPag);
                    formPago.Controls.Add(boxesIniPag.boxFormPag);
                    folPago.Controls.Add(boxesIniPag.boxFolPag);
                    impPago.Controls.Add(boxesIniPag.boxImpPag);
                    conteoPag++;

                }

            }
            else
            {
                boxesIniPag = utils.crearBoxesIniPag(conteoPag.ToString(), listadoPagos.Count.ToString());
                numPago.Controls.Add(boxesIniPag.boxNumPag);
                formPago.Controls.Add(boxesIniPag.boxFormPag);
                folPago.Controls.Add(boxesIniPag.boxFolPag);
                impPago.Controls.Add(boxesIniPag.boxImpPag);
                conteoPag++;
            }

        }
        protected Boolean agregarDatosPago()
        {
            Boolean pagosValidados = true;
            BoxesPagos boxesPagos = new BoxesPagos();

            var textboxValues = new List<string>();
            if (Request.Form.HasKeys() && listadoPagos.Count > 0)
            {
                string key = string.Empty;
                string contador = (listadoPagos.Count - 1).ToString();

                key = Request.Form.AllKeys.Where(i => i.Contains((contador + "_Pag_Num"))).FirstOrDefault();
                listadoPagos[(listadoPagos.Count - 1)].numPag = Request.Form[key];

                key = Request.Form.AllKeys.Where(i => i.Contains((contador + "_Pag_For"))).FirstOrDefault();
                listadoPagos[(listadoPagos.Count - 1)].formPag = Request.Form[key];

                key = Request.Form.AllKeys.Where(i => i.Contains((contador + "_Pag_Fol"))).FirstOrDefault();
                listadoPagos[(listadoPagos.Count - 1)].folPag = Request.Form[key];

                key = Request.Form.AllKeys.Where(i => i.Contains((contador + "_Pag_Imp"))).FirstOrDefault();
                listadoPagos[(listadoPagos.Count - 1)].impPag = Request.Form[key];


                if (listadoPagos[(listadoPagos.Count - 1)].formPag == "" || listadoPagos[(listadoPagos.Count - 1)].folPag == "" || listadoPagos[(listadoPagos.Count - 1)].impPag == "" || listadoPagos[(listadoPagos.Count - 1)].formPag == "" || listadoPagos[(listadoPagos.Count - 1)].folPag == "" || listadoPagos[(listadoPagos.Count - 1)].impPag == "")
                {
                    pagosValidados = false;
                }
            }
            return pagosValidados;
        }




        //*************************************************

        protected void ButtonGuardar_Click(object sender, EventArgs e)
        {
            if (!validarGeneral())
            {

                mostrarBoxesArticulos();
                mostrarBoxesPagos();
                return;

            }

            if (!validarArts())
            {

                mostrarBoxesArticulos();
                mostrarBoxesPagos();
                return;

            }

            if (!validarPagos())
            {

                mostrarBoxesArticulos();
                mostrarBoxesPagos();
                return;

            }

            generalesLectura();
            mostrarBoxesArticulos();
            mostrarBoxesPagos();


            if (DropDownListTipoDoc.SelectedValue == "07")
            {
                string respuesta = guardarORIN();
                int result = 0;
                try
                {
                    result = Int32.Parse(respuesta);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Unable to parse '{respuesta}'");
                }

                listadoArts.ForEach(art =>
               {
                   string respuesta2 = guardarRin(result, art);
               });
                listadoPagos.ForEach(pag =>
               {
                   string respuesta3 = guardarVpm(result, pag);
               });
            }
            else
            {
                string respuesta = guardarOINV();
                int result = 0;
                try
                {
                    result = Int32.Parse(respuesta);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Unable to parse '{respuesta}'");
                }

                listadoArts.ForEach(art =>
                {
                    string sku = art.codArt;
                    string respuesta2 = guardarINV(result, art);
                    if(sku == "8000012721A" || sku == "8000012791A" || sku == "8000013181A")
                    {
                        string respuesta4 = guardarINV2(result, art);
                    }
                });
                listadoPagos.ForEach(pag =>
                {
                    string respuesta3 = guardarRCT(result, pag);
                });
                //string respuesta2 = guardarINV(result);
                //string respuesta3 = guardarINV(result);
            }

        }



        private string guardarORIN()
        {

            string folio = TextBoxCorrelativo.Text;
            while (folio.Length < 8)
            {
                folio = "0" + folio;
            }

            string temp = TextBoxFecha.Text;
            string tbFecha = TextBoxFecha.Text.Substring(0, 4) + TextBoxFecha.Text.Substring(5, 2) + TextBoxFecha.Text.Substring(8, 2); ;

            Repositorio repo = new Repositorio();
            ORIN nuevoOrin = new ORIN();

            nuevoOrin.DocType = "I";
            nuevoOrin.DocDate = tbFecha;
            nuevoOrin.TaxDate = tbFecha;
            nuevoOrin.DocDueDate = tbFecha;
            nuevoOrin.CardCode = ConfigurationManager.AppSettings["codigoSap"];
            nuevoOrin.LicTradNum = "1";
            nuevoOrin.comments = TextBoxCliente.Text;
            nuevoOrin.DocSubType = "IB";
            nuevoOrin.NumAtCard = DropDownListTipoDoc.SelectedValue + TextBoxSerie.Text + "-" + folio;
            nuevoOrin.U_BPP_OPER = "A";
            nuevoOrin.U_BPP_MDTD = DropDownListTipoDoc.SelectedValue;
            nuevoOrin.U_BPV_SERI = TextBoxSerie.Text + "-" + DropDownListTipoDoc.SelectedValue;
            nuevoOrin.U_BPV_NCON2 = TextBoxCorrelativo.Text;
            nuevoOrin.U_BPP_MDSD = TextBoxSerie.Text;
            nuevoOrin.U_BPP_MDCD = TextBoxCorrelativo.Text;
            nuevoOrin.U_BPP_MDTO = DropDownListTipoDoc.SelectedValue;
            nuevoOrin.U_BPP_MDSO = TextBoxSerie.Text;
            nuevoOrin.U_BPP_SDOCTOTAL = TextBoxMontoTotal.Text;
            nuevoOrin.U_BPP_SDOCDATE = tbFecha;
            nuevoOrin.U_BPP_SDOCTC = "1";
            nuevoOrin.U_APTOS_FECHAEMISION = tbFecha;
            nuevoOrin.U_APTOS_HORAEMISION = "00:00:00";
            nuevoOrin.U_APTOS_COD_VENDEDOR = "99999999";
            nuevoOrin.U_APTOS_TPO_DOCTO = "";
            nuevoOrin.U_APTOS_NUM_TERMINAL = "1";
            nuevoOrin.DocTotal = TextBoxMontoTotal.Text;

            string mensaje = repo.guardarOrin(nuevoOrin);
            Response.Write(mensaje);
            return mensaje;
        }

        private string guardarOINV()
        {
            string folio = TextBoxCorrelativo.Text;
            while (folio.Length < 8)
            {
                folio = "0" + folio;
            }

            string temp = TextBoxFecha.Text;
            string tbFecha = TextBoxFecha.Text.Substring(0, 4) + TextBoxFecha.Text.Substring(5, 2) + TextBoxFecha.Text.Substring(8, 2);

            Repositorio repo = new Repositorio();
            OINV nuevoOinv = new OINV();

            nuevoOinv.DocType = "I";
            nuevoOinv.DocDate = tbFecha;
            nuevoOinv.TaxDate = tbFecha;
            nuevoOinv.DocDueDate = tbFecha;
            nuevoOinv.CardCode = ConfigurationManager.AppSettings["codigoSap"];
            nuevoOinv.LicTradNum = "1";
            nuevoOinv.comments = TextBoxCliente.Text;
            nuevoOinv.DocSubType = "IB";
            nuevoOinv.NumAtCard = DropDownListTipoDoc.SelectedValue + TextBoxSerie.Text + "-" + folio;
            nuevoOinv.U_BPP_OPER = "A";
            nuevoOinv.U_BPP_MDTD = DropDownListTipoDoc.SelectedValue;
            nuevoOinv.U_BPV_SERI = TextBoxSerie.Text + "-" + DropDownListTipoDoc.SelectedValue;
            nuevoOinv.U_BPV_NCON2 = TextBoxCorrelativo.Text;
            nuevoOinv.U_BPP_MDSD = TextBoxSerie.Text;
            nuevoOinv.U_BPP_MDCD = TextBoxCorrelativo.Text;
            nuevoOinv.U_BPP_MDTO = DropDownListTipoDoc.SelectedValue;
            nuevoOinv.U_BPP_MDSO = TextBoxSerie.Text;
            nuevoOinv.U_BPP_SDOCTOTAL = TextBoxMontoTotal.Text;
            nuevoOinv.U_BPP_SDOCDATE = tbFecha;
            nuevoOinv.U_BPP_SDOCTC = "1";
            nuevoOinv.U_APTOS_FECHAEMISION = tbFecha;
            nuevoOinv.U_APTOS_HORAEMISION = "00:00:00";
            nuevoOinv.U_APTOS_COD_VENDEDOR = "99999999";
            nuevoOinv.U_APTOS_TPO_DOCTO = "";
            nuevoOinv.U_APTOS_NUM_TERMINAL = "1";
            nuevoOinv.DocTotal = TextBoxMontoTotal.Text;

            string mensaje = repo.guardarOinv(nuevoOinv);
            Response.Write(mensaje);
            return mensaje;
        }

        private string guardarINV(int docNum, BoxesArticulos boxArts)
        {


            string precio = boxArts.precioArt;

            Decimal dec = decimal.Parse(precio, CultureInfo.InvariantCulture);
            Decimal number1 = 1.18m;
            Decimal number2 = dec / number1;
            string preSin = number2.ToString("#.######");

            string linNum = (Int32.Parse(boxArts.numArt) - 1).ToString();

            Repositorio repo = new Repositorio();
            INV objInv = new INV();

            objInv.DocNum = docNum;
            objInv.LineNum = linNum;
            //TODO codigo sku
            objInv.ItemCode = boxArts.codArt;
            objInv.Quantity = "1";
            objInv.Price = preSin;
            objInv.U_MNSO_ValorDsco = "0";
            objInv.WhsCode = ConfigurationManager.AppSettings["codigoSap"];
            objInv.CodeBars = boxArts.codArt;
            objInv.TaxCode = "18";
            objInv.LineTotal = preSin;
            objInv.U_tipoOpT12 = "1";
            objInv.U_BPP_OPER = "A";
            objInv.U_BPP_SUJETORENTA = "N";
            objInv.TaxOnly = "tNO";

            string mensaje = repo.guardarInv(objInv);
            Response.Write(mensaje);
            return mensaje;
        }

        private string guardarRin(int docNum, BoxesArticulos boxArt)
        {
            Repositorio repo = new Repositorio();
            RIN objInv = new RIN();

            objInv.DocNum = docNum;
            objInv.LineNum = boxArt.numArt;
            objInv.ItemCode = boxArt.codArt;
            objInv.Quantity = "1";
            objInv.Price = boxArt.precioArt;
            objInv.U_MNSO_ValorDsco = "0";
            objInv.WhsCode = "PR016-DI";
            objInv.CodeBars = boxArt.codArt;
            objInv.TaxCode = "18";
            objInv.LineTotal = boxArt.precioArt;
            objInv.U_tipoOpT12 = "1";
            objInv.U_BPP_OPER = "A";
            objInv.U_BPP_SUJETORENTA = "N";
            objInv.TaxOnly = "tNO";

            string mensaje = repo.guardarRin(objInv);
            Response.Write(mensaje);
            return mensaje;
        }
        private string guardarRCT(int docNum, BoxesPagos boxPag)
        {
            Repositorio repo = new Repositorio();
            RCT objRct = new RCT();
            int conDocNum = repo.obtContadorFormaPagoRct(boxPag.formPag);
            objRct.DocNum1 = docNum;
            objRct.DoCNum = conDocNum.ToString();
            objRct.LineNum = "0";
            objRct.DocEntry = boxPag.folPag;
            objRct.SumApplied = boxPag.impPag;
            objRct.InvType = "13";

            string mensaje = repo.guardarRct(objRct);
            Response.Write(mensaje);
            return mensaje;
        }


        private string guardarINV2(int docNum, BoxesArticulos boxArt)
        {
            Repositorio repo = new Repositorio();
            INV2 objInv2 = new INV2();

            objInv2.DocNum = docNum.ToString();
            objInv2.LineNum = "0";
            objInv2.ExpnsCode = "1";
            objInv2.ExpnsCode = "0.2";  

            string mensaje = repo.guardarInv2(objInv2);
            Response.Write(mensaje);
            return mensaje;
        }

        private string guardarVpm(int docNum, BoxesPagos boxPago)
        {
            Repositorio repo = new Repositorio();
            VPM objVpm = new VPM();
            int conDocNum = repo.obtContadorFormaPagoVpm(boxPago.formPag);


            objVpm.DocNum1 = docNum;
            objVpm.DoCNum = boxPago.formPag;
            objVpm.LineNum = "0";
            objVpm.DocEntry = boxPago.folPag;
            objVpm.SumApplied = boxPago.impPag;
            objVpm.InvType = "13";

            string mensaje = repo.guardarVpm(objVpm);
            Response.Write(mensaje);
            return mensaje;
        }


        public Boolean validarGeneral()
        {
            Boolean validado = true;

            string tbFecha = TextBoxFecha.Text;
            string tbCorre = TextBoxCorrelativo.Text;
            string tbSerie = TextBoxSerie.Text;
            string tbCliente = TextBoxCliente.Text;
            string tbDoc = DropDownListTipoDoc.SelectedValue;
            string tbMonTotal = TextBoxMontoTotal.Text;

            string cssLbl = "text-success";

            System.Web.UI.WebControls.Label lblFecha = new System.Web.UI.WebControls.Label();
            System.Web.UI.WebControls.Label lblCorre = new System.Web.UI.WebControls.Label();
            System.Web.UI.WebControls.Label lblSerie = new System.Web.UI.WebControls.Label();
            System.Web.UI.WebControls.Label lblCliente = new System.Web.UI.WebControls.Label();
            System.Web.UI.WebControls.Label lblMonto = new System.Web.UI.WebControls.Label();


            if (tbFecha == "")
            {
                lblFecha.Text = "Seleccione la fecha ";
                lblFecha.CssClass = cssLbl;
                Div_Fecha.Controls.Add(lblFecha);
                validado = false;
            }

            if (tbCorre == "")
            {
                lblCorre.Text = "Inserte el folio Correlativo ";
                lblCorre.CssClass = cssLbl;
                Div_Correlativo.Controls.Add(lblCorre);
                validado = false;
            }

            if (tbSerie == "")
            {
                lblSerie.Text = "Inserte la Serie ";
                lblSerie.CssClass = cssLbl;
                Div_Serie.Controls.Add(lblSerie);
                validado = false;
            }
            if (tbCliente == "")
            {
                lblCliente.Text = "Inserte nombre del cliente";
                lblCliente.CssClass = cssLbl;
                Div_Cliente.Controls.Add(lblCliente);
                validado = false;
            }
            if (tbMonTotal == "")
            {
                lblMonto.Text = "Inserta el monto total";
                lblMonto.CssClass = cssLbl;
                Div_MontoTotal.Controls.Add(lblMonto);
                validado = false;
            }
            return validado;
        }

        public void generalesLectura()
        {
            System.Web.UI.WebControls.TextBox tbFormaPago = new System.Web.UI.WebControls.TextBox();

            TextBoxFecha.ReadOnly = true;
            TextBoxCorrelativo.ReadOnly = true;
            TextBoxSerie.ReadOnly = true;
            TextBoxCliente.ReadOnly = true;
            DropDownListTipoDoc.CssClass = "form-control";
            DropDownListTipoDoc.Enabled = false;
            TextBoxMontoTotal.ReadOnly = true;
        }

        public Boolean validarArts()
        {
            Boolean validado = true;

            System.Web.UI.WebControls.Label lblCod = new System.Web.UI.WebControls.Label();
            System.Web.UI.WebControls.Label lblPre = new System.Web.UI.WebControls.Label();
            string cssLbl = "text-success";

            //mostrarBoxesArticulos();
            //mostrarBoxesPagos();


            if (listadoArts.Count > 0)
            {

                int total = listadoArts.Count - 1;
                if (listadoArts[total].codArt == "" || listadoArts[total].codArt == "")
                {
                    lblCod.Text = "Inserta el codigo de barras";
                    lblCod.CssClass = cssLbl;
                    codBarras.Controls.Add(lblCod);
                    validado = false;
                }
                if (listadoArts[total].precioArt == "" || listadoArts[total].precioArt == "")
                {
                    lblPre.Text = "Inserta el precio ";
                    lblPre.CssClass = cssLbl;
                    precio.Controls.Add(lblPre);
                    validado = false;
                }

            }

            return validado;
        }
        public Boolean validarPagos()
        {
            Boolean validado = true;

            System.Web.UI.WebControls.Label lblForm = new System.Web.UI.WebControls.Label();
            System.Web.UI.WebControls.Label lblFol = new System.Web.UI.WebControls.Label();
            System.Web.UI.WebControls.Label lblImp = new System.Web.UI.WebControls.Label();
            string cssLbl = "text-success";


            if (listadoPagos.Count > 0)
            {

                int total = listadoPagos.Count - 1;
                if (listadoPagos[total].formPag == "" || listadoPagos[total].formPag == "")
                {
                    lblForm.Text = "Inserta la frma de pago";
                    lblForm.CssClass = cssLbl;
                    formPago.Controls.Add(lblForm);
                    validado = false;
                }
                if (listadoPagos[total].folPag == "" || listadoPagos[total].folPag == "")
                {
                    lblFol.Text = "Inserta el folio ";
                    lblFol.CssClass = cssLbl;
                    folPago.Controls.Add(lblFol);
                    validado = false;
                }
                if (listadoPagos[total].impPag == "" || listadoPagos[total].impPag == "")
                {
                    lblImp.Text = "Inserta el Importe ";
                    lblImp.CssClass = cssLbl;
                    impPago.Controls.Add(lblImp);
                    validado = false;
                }

            }

            return validado;
        }



        protected void ButtonNuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Registro");
        }

        protected void ButtonTest_Click(object sender, EventArgs e)
        {
            Repositorio re = new Repositorio();

            int contador = re.obtContadorFormaPagoRct("1");

            if (true)
            {

            }
        }
    }
}