<%@ Page Title="Register Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="PortalMiniso.Registro" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="page-header">
        <h1 class="text-center">Registro de transacción</h1>
    </div>

    <div class="container ">


        <h2>Informacion General</h2>

        <div class="row" id="Inf_General">
            <div class="col-lg-3 col-md-4 col-sm-6 col-6 pb-1" runat="server" id="Div_Fecha">
                <label class="text">Fecha de transacción</label>
                <asp:TextBox class="form-control" ID="TextBoxFecha" runat="server" TextMode="Date" value="dd. MM. yyyy"></asp:TextBox>
            </div>
            <div class="col-lg-2 col-md-4 col-sm-6 col-6 pb-1" runat="server" id="Div_Correlativo">
                <label class="text">Correlativo</label>
                <asp:TextBox class="form-control" ID="TextBoxCorrelativo" runat="server" TextMode="Number"></asp:TextBox>
            </div>
            <div class="col-lg-2 col-md-4 col-sm-3 col-3 pb-1" runat="server" id="Div_Serie">
                <label class="text">Serie</label>
                <asp:TextBox class="form-control" ID="TextBoxSerie" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-5 col-md-12 col-sm-9 col-9 pb-1" runat="server" id="Div_Cliente">
                <label class="text">Cliente</label>
                <asp:TextBox class="form-control" ID="TextBoxCliente" runat="server"></asp:TextBox>
            </div>
            <div class="col-lg-3 col-md-4 col-sm-6 col-6 pb-1" runat="server" id="Div_TipoDoc">
                <label class="text">Tipo de Documento</label>
                <asp:DropDownList class="form-control" ID="DropDownListTipoDoc" runat="server" Enabled="true">
                    <asp:ListItem Value="01" >Factura</asp:ListItem>
                    <asp:ListItem Value="03" >Boleta</asp:ListItem>
                    <asp:ListItem Value="07" >Nota de Credito</asp:ListItem>
                </asp:DropDownList>
            </div>

            <div class="col-lg-3 col-md-4 col-sm-6 col-6 pb-1" runat="server" id="Div_MontoTotal">
                <label class="text">Monto Total</label>
                <asp:TextBox class="form-control" type="number" step="any" ID="TextBoxMontoTotal" runat="server" ></asp:TextBox>
            </div> 
        </div>

        <h2 class="pt-2">Articulos</h2>

        <div class="row">

            <div class="col-lg-1 col-md-2 col-sm-2 col-2 pb-1" runat="server" id="numArticulo">
                <label class="text">N°</label>
                <!--<asp:TextBox class="form-control" ID="TextBoxNumArticulo" runat="server" ReadOnly="true"></asp:TextBox>-->
            </div>
            <!--
            <div class="col-lg-5 col-md-10 col-sm-10 col-10 " runat="server" id="descArticulo">
                <label class="text">Descripcion de articulo</label>
                <asp:TextBox class="form-control" ID="TextBoxDescArticulo" runat="server" ReadOnly="true"></asp:TextBox>
            </div>
            -->
            <div class="col-lg-3 col-md-5 col-sm-5 col-5  pb-1" runat="server" id="codBarras">
                <label class="text">Codigo de barras</label>
                <!--<asp:TextBox class="form-control" ID="TextBoxCodBarras" runat="server" ReadOnly="false"></asp:TextBox>-->
            </div>
            <div class="col-lg-3 col-md-5 col-sm-5 col-5 pb-1" runat="server" id="precio" step="any">
                <label class="text">Precio</label>
                <!--<asp:TextBox class="form-control" ID="TextBoxPrecio" runat="server" ReadOnly="false"></asp:TextBox>-->
            </div>
            <!--
            <div class="col-lg-1 col-md-6 col-sm-6 col-6" style="display: flex; align-items: flex-end;">
                <asp:Button Class="btn btn-block btn-primary align-content-center" ID="Button3" runat="server" Text="X" />
            </div>
            -->
            <div class=" offset-lg-2 col-lg-3 col-md-12 col-sm-12 col-12 pb-1" style="display: flex; align-items: flex-end;">
                <asp:Button Class="btn btn-block btn-primary" ID="ButtonArticulos" runat="server" Text="Agregar articulo" OnClick="agregarArticulo" />
            </div>
        </div>





        <h2 class="pt-2">Forma de pago</h2>

        <div class="row">
            <div class="col-lg-1 col-md-2 col-sm-2 col-2 " runat="server" id="numPago">
                <label class="text">N°</label>
                <!--<asp:TextBox class="form-control" ID="TextBoxNmPago" runat="server" ReadOnly="true"></asp:TextBox>-->
            </div>
            <div class="col-lg-2 col-md-4 col-sm-12 col-12 " runat="server" id="formPago">
                <label class="text">Forma de Pago</label>
                <!--
                <asp:DropDownList class="form-control" ID="DropDownListFormaPago" runat="server" DataSourceID="SqlDataSource1" DataTextField="TENDER_NAME" DataValueField="TENDER_ID"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PlantillasConnectionString %>" SelectCommand="SELECT [TENDER_ID], [TENDER_NAME] FROM [CUENTAS]"></asp:SqlDataSource>
                -->
                <!--<asp:TextBox class="form-control" ID="TextBoxFormaPago" runat="server" ReadOnly="false"></asp:TextBox>-->
            </div>
            <div class="col-lg-3 col-md-3 col-sm-6 col-6" runat="server" id="folPago">
                <label class="text">Folio</label>
                <!--<asp:TextBox class="form-control" ID="TextBoxFolioPago" runat="server" ReadOnly="false"></asp:TextBox>-->
            </div>
            <div class="col-lg-3 col-md-3 col-sm-6 col-6" runat="server" id="impPago">
                <label class="text">Monto</label>
                <!--<asp:TextBox class="form-control" ID="TextBoxMontoPago" runat="server" ReadOnly="false"></asp:TextBox>-->
            </div>
            <!--
            <div class="col-lg-1 col-md-6 col-sm-6 col-6" style="display: flex; align-items: flex-end;">
                <asp:Button Class="btn btn-block btn-primary align-content-center" ID="Button1" runat="server" Text="X" />
            </div>
            -->
            <div class="col-lg-3 col-md-4 col-sm-12 col-12" style="display: flex; align-items: flex-end;">
                <asp:Button Class="btn btn-block btn-primary align-content-center" ID="ButtonPagos" runat="server" Text="Agregar forma de pago" OnClick="agregarPagos" />
            </div>
        </div>
        <div class="row pt-2">
            <div class="col-lg-4 col-md-4 col-sm-6 col-6 pt-2">
                <asp:Button Class="btn btn-block btn-danger" ID="ButtonNuevo" runat="server" OnClick="ButtonNuevo_Click" Text="Borrar datos" />

            </div>
            <div class="offset-lg-4 col-lg-4 col-md-4 col-sm-6 col-6 pt-2">
                <asp:Button Class="btn btn-block btn-success" ID="ButtonGuardar" runat="server" OnClick="ButtonGuardar_Click" Text="Registrar" />

            </div>
        </div>
    </div>
    <asp:Button ID="ButtonTest" runat="server" Text="Button" OnClick="ButtonTest_Click" />
</asp:Content>
