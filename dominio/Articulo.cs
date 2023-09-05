using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace dominio
{
    public class Articulo
    {
        public int Id { get; set; }

        [DisplayName("Código")]
        public string Codigo { get; set; }
        public string Nombre { get; set; }

        [DisplayName("Descripción")]
        public string Descripcion { get; set; }
   
        [DisplayName("Dirección Imagen")]
        public string ImagenUrl { get; set; } 
        public Marca Marca { get; set; }
        public Categoria Dispositivo { get; set; }
        public float Precio { get; set; }

    }
}
