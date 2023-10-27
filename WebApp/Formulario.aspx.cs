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
    public partial class Formulario : System.Web.UI.Page
    {
        public bool validacionEliminar = false;
        public string ImagenUrl { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Validaciones.EsAdmin(Session["user"]) && Validaciones.UsuarioActivo(Session["user"]))
            {
                txtId.Enabled = false;

                ArticuloNegocio negocio = new ArticuloNegocio();
                CategoriaNegocio catNego = new CategoriaNegocio();
                MarcaNegocio marNego = new MarcaNegocio();

                try
                {
                    if (!IsPostBack)
                    {
                        List<Articulo> listArticulo = negocio.listarConSP();
                        Session["listArticulo"] = listArticulo;

                        List<Marca> listMarca = marNego.listar();
                        ddlMarca.DataSource = listMarca;
                        ddlMarca.DataTextField = "Descripcion";
                        ddlMarca.DataValueField = "Id";
                        ddlMarca.DataBind();

                        List<Categoria> listCategoria = catNego.listar();
                        ddlCategoria.DataSource = listCategoria;
                        ddlCategoria.DataTextField = "Descripcion";
                        ddlCategoria.DataValueField = "Id";
                        ddlCategoria.DataBind();
                    }

                    string id = Request.QueryString["id"] != null ? Request.QueryString["id"] : string.Empty;

                    if (id != string.Empty && !IsPostBack)
                    {
                        ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                        Articulo artSeleccionado = (articuloNegocio.listar(id))[0];

                        txtId.Text = artSeleccionado.Id.ToString();
                        txtCodigo.Text = artSeleccionado.Codigo;
                        txtNombre.Text = artSeleccionado.Nombre;
                        txtDescripcion.Text = artSeleccionado.Descripcion;
                        txtPrecio.Text = artSeleccionado.Precio.ToString();
                        txtImagen.Text = artSeleccionado.ImagenUrl;
                        ddlMarca.SelectedValue = artSeleccionado.Marca.Id.ToString();
                        ddlCategoria.SelectedValue = artSeleccionado.Dispositivo.Id.ToString();
                        txtImagen_TextChanged(sender, e);

                        btnAgregar.Text = "Modificar";
                    }

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                Response.Redirect("Default.aspx", false);
            }
        }

        protected void btnImagenCarga_Click(object sender, EventArgs e)
        {
            ImagenUrl = txtImagen.Text;
        }
        protected void txtImagen_TextChanged(object sender, EventArgs e)
        {
            ImagenUrl = txtImagen.Text;
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"] != null ? Request.QueryString["id"] : string.Empty;

            if (id == string.Empty)
            {
                Articulo articulo = new Articulo();
                ArticuloNegocio negocio = new ArticuloNegocio();

                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.Precio = float.Parse(txtPrecio.Text);
                articulo.ImagenUrl = txtImagen.Text;

                articulo.Marca = new Marca();
                articulo.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                articulo.Dispositivo = new Categoria();
                articulo.Dispositivo.Id = int.Parse(ddlCategoria.SelectedValue);

                negocio.agregarConSP(articulo);
                Response.Redirect("Grilla.aspx", false);
            }
            else
            {
                Articulo articulo = new Articulo();
                ArticuloNegocio negocio = new ArticuloNegocio();

                articulo.Id = int.Parse(txtId.Text);
                articulo.Codigo = txtCodigo.Text;
                articulo.Nombre = txtNombre.Text;
                articulo.Descripcion = txtDescripcion.Text;
                articulo.Precio = float.Parse(txtPrecio.Text);
                articulo.ImagenUrl = txtImagen.Text;

                articulo.Marca = new Marca();
                articulo.Marca.Id = int.Parse(ddlMarca.SelectedValue);
                articulo.Dispositivo = new Categoria();
                articulo.Dispositivo.Id = int.Parse(ddlCategoria.SelectedValue);

                negocio.modificarConSP(articulo);
                Response.Redirect("Grilla.aspx", false);
            }
        } 

        public void btnEliminar_Click(object sender, EventArgs e)
        {
            validacionEliminar = true;
        }

        protected void btnEliminarConfirmacion_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();

                articuloNegocio.eliminar(int.Parse(txtId.Text));

                Response.Redirect("Grilla.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }

        protected void btnInactivar_Click(object sender, EventArgs e)
        {
            try
            {
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();

                //articuloNegocio.eliminar();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }
    }
}
