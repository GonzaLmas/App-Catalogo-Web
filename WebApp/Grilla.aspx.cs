﻿using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApp
{
    public partial class Grilla : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();

            Session.Add("listArticulo", negocio.listarConSP());

            dgvArticulos.DataSource = Session["listArticulo"];
            dgvArticulos.DataBind();

            dgvAdmin.DataSource = Session["listArticulo"];
            dgvAdmin.DataBind();
        }

        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //captura lo que recibe del evento de la grilla la nueva página y la asigna a la página actual
            dgvArticulos.PageIndex = e.NewPageIndex;
            dgvArticulos.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Formulario.aspx", false);
        }

        protected void btnFiltrarenGrilla_Click(object sender, EventArgs e)
        {
            if (!(Validaciones.EsAdmin(Session["user"])))
            {
                List<Articulo> lista = (List<Articulo>)Session["listArticulo"];
                List<Articulo> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));

                dgvArticulos.DataSource = listaFiltrada;
                dgvArticulos.DataBind();
            }
            else
            {
                List<Articulo> lista = (List<Articulo>)Session["listArticulo"];
                List<Articulo> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));

                dgvAdmin.DataSource = listaFiltrada;
                dgvAdmin.DataBind();
            }
        }

        protected void dgvAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            //en este evento capturo el id del registro seleccinado y redirijo a la pantalla del
            //formulario envíando por URL el id del registro seleccionado
            string id = dgvAdmin.SelectedDataKey.Value.ToString();
            Response.Redirect("Formulario.aspx?id=" + id, false);
        }

        protected void dgvAdmin_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //captura lo que recibe del evento de la grilla la nueva página y la asigna a la página actual
            dgvAdmin.PageIndex = e.NewPageIndex;
            dgvAdmin.DataBind();
        }
    }
}