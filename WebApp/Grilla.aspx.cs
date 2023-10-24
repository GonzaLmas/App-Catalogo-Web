using dominio;
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

        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            //en este evento capturo el id del registro seleccinado y redirijo a la pantalla del
            //formulario envíando por URL el id del registro seleccionado
            string id = dgvArticulos.SelectedDataKey.Value.ToString();
            Response.Redirect("Formulario.aspx?id=" + id, false);
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


    }
}