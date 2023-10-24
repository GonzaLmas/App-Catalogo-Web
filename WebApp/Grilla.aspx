﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Grilla.aspx.cs" Inherits="WebApp.Grilla" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Lista de artículos</h1>

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
                <asp:Button ID="btnFiltrarenGrilla" runat="server" Text="Buscar" OnClick="btnFiltrarenGrilla_Click" CssClass="btn btn-primary" />
            </div>
        </div>
    </div>

    <%--        </ContentTemplate>
    </asp:UpdatePanel>--%>

    <asp:GridView ID="dgvArticulos" runat="server" AutoGenerateColumns="false" DataKeyNames="Id" CssClass="table table-striped"
        AllowPaging="true" PageSize="7" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged"
        OnPageIndexChanging="dgvArticulos_PageIndexChanging">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
            <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
            <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
            <asp:BoundField HeaderText="Categoria" DataField="Dispositivo.Descripcion" />
            <asp:BoundField HeaderText="Precio" DataField="Precio" />
            <asp:CommandField HeaderText="Acción" ShowSelectButton="true" SelectText="Si" />
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" CssClass="btn btn-primary" />
</asp:Content>
