<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Catálogo de productos</h1>
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="updPanel" runat="server">
        <ContentTemplate>--%>
    <div class="row" id="fila">
        <%--<div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Elegir filtro" ID="lblCampo" runat="server" />
                <asp:DropDownList runat="server" ID="ddlCampo" CssClass="btn btn-primary dropdown-toggle" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                    <asp:ListItem Text="Nombre" />
                    <asp:ListItem Text="Marca" />
                    <asp:ListItem Text="Categoria" />
                </asp:DropDownList>
            </div>
        </div>--%>
        <div class="col-6">
            <div class="col-3">
                <div class="mb-3">
                    <asp:Label Text="Búsqueda por nombre" runat="server" />
                </div>
            </div>
            <div class="input-group mb-3">
                <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" />
                <asp:Button ID="btnFiltrarEnDefault" runat="server" Text="Buscar" OnClick="btnFiltrarEnDefault_Click" CssClass="btn btn-primary" />
            </div>
        </div>
    </div>

    <%--        </ContentTemplate>
    </asp:UpdatePanel>--%>

    <div class="row row-cols-1 row-cols-md-3 g-4">
        <asp:Repeater runat="server" ID="repDefault">
            <ItemTemplate>
                <div class="col">
                    <div class="card">
                        <img src="<%#Eval("ImagenUrl")%>" class="card-img-top" alt="El dispositivo no posee imagen">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre")%></h5>
                            <h5 class="card-title"> Precio: $<%#Eval("Precio")%></h5>
                            <a href="Detalle.aspx?id=<%#Eval("Id")%>" class="btn btn-primary">Detalle</a>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
