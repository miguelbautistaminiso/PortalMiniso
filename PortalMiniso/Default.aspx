<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PortalMiniso._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container pt-2 fondo-imagen">
        <div class="row justify-content-center align-items-center">
            <div class="col-md-6">
                <div class="col-md-12 ">

                    <div class="card">
                        <h3 class="text-center text-info">Inicio de sesión</h3>
                        <div runat="server" ID="Div_Validacion" class="text-center pt-1 pb-1 ">

                        </div>

                        <div class="form-group">
                            <label class="text">Usuario</label>
                            <asp:TextBox class="form-control" ID="TextBoxUsuario" runat="server" ToolTip="Usuario" Placeholder="Usuario"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label class="text">Contraseña</label>
                            <asp:TextBox class="form-control" ID="TextBoxContraseña" runat="server" ToolTip="Contraseña" TextMode="Password" Placeholder="Contraseña"></asp:TextBox>
                        </div>

                        <div id="register-link" class="text-right">
                            <asp:Button class="btn btn-block btn-success" ID="ButtonIngresar" runat="server" OnClick="ButtonIngresar_Click" Text="Ingresar" />
                        </div>
                    </div>
            </div>
        </div>
    </div>
    </div>

</asp:Content>
