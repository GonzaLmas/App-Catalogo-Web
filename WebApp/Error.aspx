<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="WebApp.Error" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Oops, algo salió mal!</h1>
    <asp:Label Text="Error" ID="lblError" runat="server" />
    <a href="Default.aspx">Volver al inicio</a>
</asp:Content>
