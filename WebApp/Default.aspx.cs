using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace WebApp
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Articulo> ListArticulo { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Session.Add("listArticulo", negocio.listarConSP());

            repDefault.DataSource = Session["listArticulo"];
            repDefault.DataBind();
        }

        protected void btnFiltrarEnDefault_Click(object sender, EventArgs e)
        {
            List<Articulo> lista = (List<Articulo>)Session["listArticulo"];
            List<Articulo> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltro.Text.ToUpper()));

            repDefault.DataSource = listaFiltrada;
            repDefault.DataBind();
        }
    }
}