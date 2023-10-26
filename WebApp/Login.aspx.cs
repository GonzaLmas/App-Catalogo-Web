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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Usuario user;
            UsuarioNegocio negocio = new UsuarioNegocio();

            if (!(Validaciones.UsuarioActivo(Session["user"])))
            {
                try
                {
                    user = new Usuario(txtUsuario.Text, txtPasword.Text, false);

                    if (negocio.Login(user))
                    {
                        Session.Add("user", user);
                        Response.Redirect("Default.aspx", false);
                    }
                    else
                    {
                        Session.Add("error", "Email o contraseña incorrectos");
                        Response.Redirect("Login.aspx", false);
                    }
                }
                catch (Exception ex)
                {
                    Session.Add("Error.aspx", ex.ToString());
                }
            }
           
        }

    }
}