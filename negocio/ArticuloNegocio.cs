using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;


namespace negocio
{
    public class ArticuloNegocio
    {
        
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select a.Id, a.Codigo, a.Nombre, a.Descripcion, a.IdMarca, a.IdCategoria, m.Descripcion Marca, c.Descripcion Dispositivo, a.ImagenUrl, CAST(a.precio as float (1)) Precio from ARTICULOS A, MARCAS M, CATEGORIAS C where m.Id = a.IdMarca and c.Id = a.IdCategoria");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    
                    aux.Precio = (float)datos.Lector["Precio"];
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Dispositivo = new Categoria();
                    aux.Dispositivo.Id = (int)datos.Lector["IdCategoria"];
                    aux.Dispositivo.Descripcion = (string)datos.Lector["Dispositivo"];
                    
                    lista.Add(aux);
                }
              
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("insert into ARTICULOS (Codigo, Nombre, Descripcion, IdMarca,IdCategoria, ImagenUrl, Precio) values (@codigo, @nombre, @descripcion, @idMarca, @idCategoria, @imagenUrl, @precio)");
                datos.setearParametro("@codigo", nuevo.Codigo);                              
                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@descripcion", nuevo.Descripcion);
                datos.setearParametro("@idMarca", nuevo.Marca.Id);
                datos.setearParametro("@idCategoria", nuevo.Dispositivo.Id);
                datos.setearParametro("@imagenUrl", nuevo.ImagenUrl);
                datos.setearParametro("@precio", nuevo.Precio);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void modificar(Articulo modificar)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("update ARTICULOS set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @idMarca, IdCategoria = @idCategoria, ImagenUrl = @imagenUrl, Precio = @precio where id = @id");          
                datos.setearParametro("@codigo", modificar.Codigo);
                datos.setearParametro("@nombre", modificar.Nombre);
                datos.setearParametro("@descripcion", modificar.Descripcion);
                datos.setearParametro("@idMarca", modificar.Marca.Id);
                datos.setearParametro("@idCategoria", modificar.Dispositivo.Id);
                datos.setearParametro("@imagenUrl", modificar.ImagenUrl);
                datos.setearParametro("@precio", modificar.Precio);
                datos.setearParametro("@id", modificar.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "select a.Id, a.Codigo, a.Nombre, a.Descripcion, a.IdMarca, a.IdCategoria, m.Descripcion Marca, c.Descripcion Dispositivo, a.ImagenUrl, CAST(a.precio as float (1)) Precio from ARTICULOS A, MARCAS M, CATEGORIAS C where m.Id = a.IdMarca and c.Id = a.IdCategoria and ";

                if(campo == "Precio")
                {
                    if(criterio == "Mayor a")                   
                        consulta += "Precio >"  + filtro;   
                    
                    else if(criterio == "Menor a")                  
                        consulta += "Precio < " + filtro;   
                    
                    else                   
                        consulta += "Precio = " + filtro;                   
                }

                else if(campo == "Nombre")
                {
                    if (criterio == "Comienza con")
                        consulta += "Nombre like '" + filtro + "%'";

                    else if (criterio == "Termina con")
                        consulta += "Nombre like '%" + filtro + "'";
                    
                    else
                        consulta += "Nombre like '%" + filtro + "%'";
                }

                else
                {
                    if (criterio == "Comienza con")
                        consulta += "a.Descripcion like '" + filtro + "%'";

                    else if (criterio == "Termina con")
                        consulta += "a.Descripcion like '%" + filtro + "'";

                    else
                        consulta += "a.Descripcion like '%" + filtro + "%'";
                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                    aux.Precio = (float)datos.Lector["Precio"];
                    aux.Marca = new Marca();
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Dispositivo = new Categoria();
                    aux.Dispositivo.Id = (int)datos.Lector["IdCategoria"];
                    aux.Dispositivo.Descripcion = (string)datos.Lector["Dispositivo"];

                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {            
                throw ex;
            }
        }

        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("delete from ARTICULOS where id = @id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
