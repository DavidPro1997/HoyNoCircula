using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Servidor_MDQ
{
    //Clase implementada para el manejo de la DB
    public class ConexionDB
    {
        //Metodo de obtencion de conexión
        public static SqlConnection ObtenerConexion()
        {
            //Se atrapa si existe una excepcion en la conexion
            try
            {
                //Cadena de conexion
                SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-3SQ3RB8;Initial Catalog=dbHoyNoCircula;Integrated Security=True");

                //Condicion de validacion de cierre de la BD para abrirla
                if (conexion.State == System.Data.ConnectionState.Closed)
                    conexion.Open();
                return conexion;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        // Metodo que cierra la conexion a la BD
        public static void cerrarConexion(SqlConnection conexion)
        {
            try
            {
                // Valida si la conexion esta abierta para cerrarla
                if (conexion.State == System.Data.ConnectionState.Open)
                    conexion.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private SqlCommand comando = new SqlCommand();

        //Metodos de los procedimientos en la BD
        //Insertar usuario
        public void Insertar(string nombre, string apellido, string cedula, string dirip_puert)
        {
            
            comando = new SqlCommand();
            comando.Connection = ConexionDB.ObtenerConexion();
            comando.CommandText = "ingresar";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@nombre", nombre);
            comando.Parameters.AddWithValue("@apellido", apellido);
            comando.Parameters.AddWithValue("@cedula", cedula);
            comando.Parameters.AddWithValue("@direccionIp_puerto", dirip_puert);

            SqlDataReader datos = comando.ExecuteReader();
            while (datos.Read())
            {

                Console.WriteLine("INGRESANDO EN LA BASE");

            }



            //Si quiero recuperar datos
            /*while (datos.Read())
            {
               puta = (datos["nombre"].ToString());
                Console.WriteLine("hola" + puta);

            }*/

        }


        public void salvoconducto(string placa, string cedula)
        {
            
            comando = new SqlCommand();
            comando.Connection = ConexionDB.ObtenerConexion();
            comando.CommandText = "hacerSalvoconducto";
            comando.CommandType = CommandType.StoredProcedure;


            comando.Parameters.AddWithValue("@numPlaca", placa);
            comando.Parameters.AddWithValue("@idMotivo", 1);
            comando.Parameters.AddWithValue("@cedula", cedula);

            SqlDataReader estado = comando.ExecuteReader();
            while (estado.Read())
           {
                string estadobase = estado["estadoSalvoconducto"].ToString();
               Console.WriteLine(estadobase);
           }

        }








        public void horario(string placa, string cedula)
        {
            int aux = 1;
            string dia1;
            string dia2;
            comando = new SqlCommand();
            comando.Connection = ConexionDB.ObtenerConexion();
            comando.CommandText = "mostrarHorario";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@numPlaca", placa);
            comando.Parameters.AddWithValue("@cedula", cedula);

            SqlDataReader estado = comando.ExecuteReader();
            while (estado.Read())
            {
                //Console.WriteLine("INGRESANDO EN LA BASE");
                if (aux == 1)
                {
                    dia1 = estado["dia"].ToString();
                    aux = 0;
                    Console.WriteLine(dia1);
                }
                else
                {
                    dia2 = estado["dia"].ToString();
                    Console.WriteLine(dia2);
                }
  
            }
            

            

        }



    }


    
}