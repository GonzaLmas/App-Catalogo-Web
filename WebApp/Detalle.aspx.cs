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
    public partial class Detalle : System.Web.UI.Page
    {
        public string ImagenUrl { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"] : string.Empty;

                if (id != string.Empty && !IsPostBack)
                {
                    ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                    Articulo artSeleccionado = (articuloNegocio.listar(id))[0];

                    txtCodigoDetll.Text = artSeleccionado.Codigo;
                    txtNombreDetll.Text = artSeleccionado.Nombre;
                    txtDescripcionDetll.Text = artSeleccionado.Descripcion;
                    txtPrecioDetll.Text = artSeleccionado.Precio.ToString();
                    txtImagenDetll.Text = artSeleccionado.ImagenUrl;
                    txtImagenDetll_TextChanged(sender, e);

                    txtCodigoDetll.Enabled = false;
                    txtNombreDetll.Enabled = false;
                    txtDescripcionDetll.Enabled = false;
                    txtPrecioDetll.Enabled = false;
                    txtImagenDetll.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error.aspx", false);
            }
        }

        protected void txtImagenDetll_TextChanged(object sender, EventArgs e)
        {
            ImagenUrl = txtImagenDetll.Text;
        }
    }
}