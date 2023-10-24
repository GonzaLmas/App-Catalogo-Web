<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" Inherits="WebApp.Formulario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-6">
                <div class="mb-3">
                    <asp:Label ID="lblId" runat="server" Text="Id" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtId" runat="server" CssClass="form-control" Enabled="false"> </asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblCodigo" runat="server" Text="Código" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control"> </asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblNombre" runat="server" Text="Nombre" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"> </asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblDescripcion" runat="server" Text="Descripción" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" TextMode="MultiLine" type="multiline"> </asp:TextBox>
                </div>
                <div class="mb-3">
                    <asp:Label ID="lblPrecio" runat="server" Text="Precio" CssClass="form-label"></asp:Label>
                    <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control"> </asp:TextBox>
                </div>

                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <asp:UpdatePanel ID="updPanel" runat="server">
                    <ContentTemplate>
                        <div class="mb-3">
                            <asp:Label ID="lblMarca" runat="server" Text="Marca" CssClass="form-label"></asp:Label>
                            <asp:DropDownList ID="ddlMarca" runat="server" CssClass="btn btn-primary dropdown-toggle" AutoPostBack="true">
                            </asp:DropDownList>
                        </div>
                        <div class="mb-3">
                            <asp:Label ID="lblCategoria" runat="server" Text="Categoria" CssClass="form-label"></asp:Label>
                            <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="btn btn-primary dropdown-toggle"></asp:DropDownList>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                    <ContentTemplate>
                        <div class="mb-3">
                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" CssClass="btn btn-outline-danger" />
                            <% if (validacionEliminar)
                                { %>
                            <div class="mb-3">
                                <asp:Button ID="btnEliminarConfirmacion" runat="server" Text="Si, eliminar" OnClick="btnEliminarConfirmacion_Click" CssClass="btn btn-danger" />
                                <a href="ListaArticulos.aspx" class="btn btn-dark">Cancelar</a>
                                <asp:Button ID="btnInactivar" runat="server" Text="Inactivar" OnClick="btnInactivar_Click" CssClass="btn btn-warning" />
                            </div>
                            <% } %>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>

            <div class="col-6">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <div class="mb-3">
                            <asp:Label ID="lblImagen" runat="server" Text="Imagen" CssClass="form-label"></asp:Label>
                            <asp:TextBox ID="txtImagen" runat="server" OnTextChanged="txtImagen_TextChanged"
                                AutoPostBack="true" CssClass="form-control"></asp:TextBox>
                            <img src="<% = ImagenUrl%>" class="rounded" alt="..." width="65%">
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="mb-3">
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-primary" OnClick="btnAgregar_Click" />
                    <a href="#" class="btn btn-danger">Cancelar</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
