<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApp.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 style="margin-top: 30px; margin-bottom: 15px">Ingrese sus datos</h1>
    <%if (!(negocio.Validaciones.UsuarioActivo(Session["user"])))
        {  %>
    <div class="container">
        <div class="row" style="margin-bottom: 45px">
            <div class="col-4">
                <div class="mb-3">
                    <asp:Label ID="lblUsuario" runat="server" Text="Email" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblPassword" runat="server" Text="Contraseña" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtPasword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                </div>
                <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" CssClass="btn btn-primary" />
            </div>
        </div>
    </div>
    <%}%>
</asp:Content>
