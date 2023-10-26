<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="WebApp.Detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Detalle del producto</h1>
    <div class="container">
        <div class="row">
            <div class="col-6">
                <div class="mb-3">
                    <asp:Label ID="lblCodigoDetll" runat="server" Text="Código" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtCodigoDetll" runat="server" CssClass="form-control"> </asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblNombreDetll" runat="server" Text="Nombre" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtNombreDetll" runat="server" CssClass="form-control"> </asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblDescripcionDetll" runat="server" Text="Descripción" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtDescripcionDetll" runat="server" CssClass="form-control" TextMode="MultiLine" type="multiline"> </asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblPrecioDetll" runat="server" Text="Precio" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtPrecioDetll" runat="server" CssClass="form-control"> </asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblMarca" runat="server" Text="Marca" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtMarca" runat="server" CssClass="form-control"> </asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblCategoria" runat="server" Text="Categoría" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtCategoria" runat="server" CssClass="form-control"> </asp:TextBox>
                </div>
            </div>
            <div class="col-6">
                <div class="mb-3">
                    <asp:Label ID="lblImagenDetll" runat="server" Text="Imagen" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtImagenDetll" runat="server" OnTextChanged="txtImagenDetll_TextChanged"
                        AutoPostBack="true" CssClass="form-control"></asp:TextBox>
                    <img src="<% = ImagenUrl%>" class="rounded" alt="..." width="65%">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
