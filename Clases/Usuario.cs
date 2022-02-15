using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Usuario
    {
        private string cedula;
        private string nombre;
        private string apellido;
        private string direccionip;
    

        public Usuario(string cedula, string nombre, string apellido, string direccionip)
        {
            this.Cedula = cedula;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Direccionip = direccionip;
        
        }

        public string Cedula { get => cedula; set => cedula = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Direccionip { get => direccionip; set => direccionip = value; }
       



    }
}
