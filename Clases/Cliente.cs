using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Clases
{
    public class Cliente
    {
        //Método crear canción
        public bool Ingresar(Usuario usuario)
        {
            //Creación de un punto final de conexión con la dirección de loopback y con el puerto 11000
            IPEndPoint remoto = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000);
            //Creación cliente TCP
            TcpClient cliente = new TcpClient();

            usuario.Direccionip =  Convert.ToString(cliente.Client.RemoteEndPoint);

            //Establecemos la conexión a través del punto final creado
            cliente.Connect(remoto);
            //Verificamos si se tiene una conexión exitosa
            if (cliente.Connected)
            {
                //Creamos un flujode datos para el acceso a la red, es decir enviar y recibir datos
                NetworkStream flujo = cliente.GetStream();
                //Declaramos variable datos para tener una cadena de caracteres el simbolo ";" separa
                //cada dato en la cadena
                string datos = usuario.Nombre + ";" +
                    usuario.Apellido + ";" +
                    usuario.Cedula + ";" +
                    usuario.Direccionip;
                 
                //Creamos un arreglo de bytes en el cual se almacenarán los datos codificados a ser enviados
                byte[] bufferTx = Encoding.ASCII.GetBytes("Crear;" + datos);
                //Escribimos los datos en el flujo de red creado anteriormente, en pocas palabras se manda
                //la información
                flujo.Write(bufferTx, 0, bufferTx.Length);
                //Cerramos la conexión
                cliente.Close();

            }
            else
            {
                //Mensaje en consola de falla de conexión
                Console.WriteLine("La conexión falló");
            }
            return true;
        }


        public void enviarPlaca(string placa, string cedula)
        {
            //Creación de un punto final de conexión con la dirección de loopback y con el puerto 11000
            IPEndPoint remoto = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000);
            //Creación cliente TCP
            TcpClient cliente = new TcpClient();

            //Establecemos la conexión a través del punto final creado
            cliente.Connect(remoto);
            //Verificamos si se tiene una conexión exitosa
            if (cliente.Connected)
            {
                //Creamos un flujode datos para el acceso a la red, es decir enviar y recibir datos
                NetworkStream flujo = cliente.GetStream();
                //Declaramos variable datos para tener una cadena de caracteres el simbolo ";" separa
                //cada dato en la cadena
                string datos = placa + ";" +
                    cedula;

                //Creamos un arreglo de bytes en el cual se almacenarán los datos codificados a ser enviados
                byte[] bufferTx = Encoding.ASCII.GetBytes("Pedido de salvoconducto;" + datos);
                //Escribimos los datos en el flujo de red creado anteriormente, en pocas palabras se manda
                //la información
                flujo.Write(bufferTx, 0, bufferTx.Length);
                //Cerramos la conexión
                cliente.Close();

            }
            else
            {
                //Mensaje en consola de falla de conexión
                Console.WriteLine("La conexión falló");
            }
            
        }






        public void verHorario(string placa, string cedula)
        {
            //Creación de un punto final de conexión con la dirección de loopback y con el puerto 11000
            IPEndPoint remoto = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000);
            //Creación cliente TCP
            TcpClient cliente = new TcpClient();

            //Establecemos la conexión a través del punto final creado
            cliente.Connect(remoto);
            //Verificamos si se tiene una conexión exitosa
            if (cliente.Connected)
            {
                //Creamos un flujode datos para el acceso a la red, es decir enviar y recibir datos
                NetworkStream flujo = cliente.GetStream();
                //Declaramos variable datos para tener una cadena de caracteres el simbolo ";" separa
                //cada dato en la cadena
                string datos = placa + ";" +
                    cedula;

                //Creamos un arreglo de bytes en el cual se almacenarán los datos codificados a ser enviados
                byte[] bufferTx = Encoding.ASCII.GetBytes("mostrarHorario;" + datos);
                //Escribimos los datos en el flujo de red creado anteriormente, en pocas palabras se manda
                //la información
                flujo.Write(bufferTx, 0, bufferTx.Length);
                //Cerramos la conexión
                cliente.Close();

            }
            else
            {
                //Mensaje en consola de falla de conexión
                Console.WriteLine("La conexión falló");
            }

        }



    }
}
