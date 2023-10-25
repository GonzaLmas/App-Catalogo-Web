using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Admin { get; set; }

        public Usuario(string pUser, string pPassword, bool pAdmin)
        {
            Email = pUser;
            Password = pPassword;
            Admin = pAdmin;
        }
    }

    //public enum TipoUsuario
    //{
    //    ADMIN = 1,
    //    TEST = 2
    //}
}
