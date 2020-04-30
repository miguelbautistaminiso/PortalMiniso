using PortalMiniso.Entity;
using PortalMiniso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace PortalMiniso.util
{
    public class Utils
    {
        Repositorio repo = new Repositorio();
        List<CUENTAS> listaCuentas; 
        public BoxArticulo crearBoxesArt(BoxesArticulos boxesArt, string numID)
        {
            string cssBoxArt = "form-control";
            BoxArticulo boxArt = new BoxArticulo();

            var boxNum = new TextBox();
            boxNum.ReadOnly = true;
            boxNum.ID = numID + "_Art_Num";
            boxNum.CssClass = cssBoxArt;
            boxNum.Text = boxesArt.numArt;
            boxArt.boxNumArt = boxNum;

            var boxCod = new TextBox();
            boxCod.ReadOnly = true;
            boxCod.ID = numID + "_Art_Cod";
            boxCod.CssClass = cssBoxArt;
            boxCod.Text = boxesArt.codArt;
            boxArt.boxCodArt = boxCod;

            var boxDesc = new TextBox();
            boxDesc.ReadOnly = true;
            boxDesc.ID = numID + "_Art_Des";
            boxDesc.CssClass = cssBoxArt;
            boxDesc.Text = boxesArt.descArt;
            boxArt.boxDescArt = boxDesc;

            var boxPrecio = new TextBox();
            boxPrecio.ReadOnly = true;
            boxPrecio.ID = numID + "_Art_Pre";
            boxPrecio.CssClass = cssBoxArt;

            boxPrecio.Text = boxesArt.precioArt;
            boxArt.boxPrecioArt = boxPrecio;

            return boxArt;
        }
        public BoxArticulo crearBoxesIniArt(string id, string cont)
        {
            string cssBoxArt = "form-control";
            BoxArticulo boxArtIni = new BoxArticulo();

            var boxNum = new TextBox();
            boxNum.ReadOnly = true;
            boxNum.ID = id + "_Art_Num";
            boxNum.CssClass = cssBoxArt;
            boxNum.Text = cont;
            boxNum.EnableViewState = true;
            boxArtIni.boxNumArt = boxNum;

            var boxCod = new TextBox();
            boxCod.ReadOnly = false;
            boxCod.ID = id + "_Art_Cod";
            boxCod.CssClass = cssBoxArt;
            boxCod.EnableViewState = true;
            boxArtIni.boxCodArt = boxCod;

            var boxDesc = new TextBox();
            boxDesc.ReadOnly = false;
            boxDesc.ID = id + "_Art_Des";
            boxDesc.CssClass = cssBoxArt;
            boxDesc.EnableViewState = true;
            boxArtIni.boxDescArt = boxDesc;

            var boxPrecio = new TextBox();
            boxPrecio.ReadOnly = false;
            boxPrecio.ID = id + "_Art_Pre";
            boxPrecio.CssClass = cssBoxArt;
            boxPrecio.EnableViewState = true;
            boxPrecio.ValidationGroup = "[0-9]{2}";
            //boxPrecio.TextMode = TextBoxMode.Number;
            //boxPrecio.step = "any";
            boxArtIni.boxPrecioArt = boxPrecio;

            return boxArtIni;
        }
        public BoxPago crearBoxesPag(BoxesPagos boxesPag, string numID)
        {
            string cssBoxArt = "form-control";
            string cssBoxArt2 = "form-control class";
            BoxPago boxPag = new BoxPago();

            var boxNum = new TextBox();
            boxNum.ReadOnly = true;
            boxNum.ID = numID + "_Pag_Num";
            boxNum.CssClass = cssBoxArt;
            boxNum.Text = boxesPag.numPag;
            boxPag.boxNumPag = boxNum;


            listaCuentas = repo.obtCuentas();

            var listForm = new DropDownList();
            listForm.ID = numID + "_Pag_For";
            listForm.CssClass = cssBoxArt2;
            listaCuentas.ForEach(x =>
            {
                ListItem item = new ListItem();
                item.Value = x.TENDER_ID.ToString();
                item.Text = x.TENDER_NAME;
                listForm.Items.Add(item);
            });
            listForm.SelectedValue = boxesPag.formPag;
            listForm.Enabled = false;
            boxPag.boxFormPag = listForm;

            /*
            var boxForm = new TextBox();
            boxForm.ReadOnly = true;
            boxForm.ID = numID + "_Pag_For";
            boxForm.CssClass = cssBoxArt;
            boxForm.Text = boxesPag.formPag;
            boxPag.boxFormPag = boxForm;
            */

            var boxFol = new TextBox();
            boxFol.ReadOnly = true;
            boxFol.ID = numID + "_Pag_Fol";
            boxFol.CssClass = cssBoxArt;
            boxFol.Text = boxesPag.folPag;
            boxPag.boxFolPag = boxFol;

            var boxImp = new TextBox();
            boxImp.ReadOnly = true;
            boxImp.ID = numID + "_Pag_Imp";
            boxImp.CssClass = cssBoxArt;
            boxImp.Text = boxesPag.impPag;
            boxPag.boxImpPag = boxImp;

            return boxPag;
        }
        public BoxPago crearBoxesIniPag(string id, string cont)
        {
            string cssBoxPag = "form-control";
            BoxPago boxPagIni = new BoxPago();

            var boxNum = new TextBox();
            boxNum.ReadOnly = true;
            boxNum.ID = id + "_Pag_Num";
            boxNum.CssClass = cssBoxPag;
            boxNum.Text = cont;
            boxNum.EnableViewState = true;
            boxPagIni.boxNumPag = boxNum;

            listaCuentas = repo.obtCuentas();
            var ListForm = new DropDownList();
            ListForm.ID = id + "_Pag_For";
            ListForm.CssClass = cssBoxPag;
            ListForm.EnableViewState = true;
            listaCuentas.ForEach(x =>
            {
                ListItem item = new ListItem();
                item.Value = x.TENDER_ID.ToString();
                item.Text = x.TENDER_NAME;
                ListForm.Items.Add(item);
            });
            boxPagIni.boxFormPag = ListForm;


            /*
            var boxForm = new TextBox();
            boxForm.ReadOnly = false;
            boxForm.ID = id + "_Pag_For";
            boxForm.CssClass = cssBoxPag;
            boxForm.EnableViewState = true;
            boxPagIni.boxFormPag = boxForm;
            */
            var boxFol = new TextBox();
            boxFol.ReadOnly = false;
            boxFol.ID = id + "_Pag_Fol";
            boxFol.CssClass = cssBoxPag;
            boxFol.EnableViewState = true;
            boxPagIni.boxFolPag = boxFol;

            var boxImp = new TextBox();
            boxImp.ReadOnly = false;
            boxImp.ID = id + "_Pag_Imp";
            boxImp.CssClass = cssBoxPag;
            boxImp.EnableViewState = true;
            boxPagIni.boxImpPag = boxImp;

            return boxPagIni;
        }
    }
}