using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using Servidor_MDQ;

namespace Servidor_MDQ
{
    public class Servidor
    {
        //string cadena;
        static void Main(string[] args)
        {
            //Creamos objeto de la clase servidor
            Servidor servidor = new Servidor();
            //Llamamos al método escuchaPetición para atender al cliente
            servidor.escucharPeticion();
        }

        //Método para escuchar peticiones del cliente
        public void escucharPeticion()
        {
            //Creamos objeto cliente TCP para atender las peticiones
            TcpClient manejoCliente;
            //Creamos objeto servidor TCP para escuchar peticiones del cliente
            TcpListener servidor;
            //Declaramos arreglo de bytes para la recepción de mensajes y definimos
            //su tamaño
            byte[] bufferRx = new byte[512];
            //Declaramos variable para contabilizar los datos recibidos 
            int datosLeidos;
            //Declaramos variable para almacenar los datos recibidos
            string datos;
            //Creamos punto de final de conexión con una dirección IP cualquiera y puerto 11000
            IPEndPoint puntoLocal = new IPEndPoint(IPAddress.Any, 11000);
            //Servidor escuchará a través del punto final creado anteriormente
            servidor = new TcpListener(puntoLocal);
            //Mostramos mensaje de escucha en la consola
            Console.WriteLine("El servidor está escuchado...");
            //Iniciamos la escucha del servidor
            servidor.Start();
            while (true)
            {
                //Aceptamos la solicitud del cliente
                manejoCliente = servidor.AcceptTcpClient();
                //Creamos flujo de red para enviar y recibir datos
                NetworkStream flujo = manejoCliente.GetStream();
                do
                {
                    //Leemos los datos del flujo de red, es decir se reciben los datos
                    datosLeidos = flujo.Read(bufferRx, 0, bufferRx.Length);
                    //Verificamos si se recibieron datos
                    if (datosLeidos > 0)
                    {
                        //Decodificaos los datos recibidos en el arreglo de bytes
                        datos = Encoding.ASCII.GetString(bufferRx);
                        //Declaramos un arreglo de tipo string para poder separar los datos recibidos
                        //según el simbolo ";"
                        string[] datosSeparados = datos.Split(';');

                        //Creamos un menú de tareas que se ejecutarán según la petición por el cliente
                        //para esto se verifica el primer valor de la cadena recibida
                        switch (datosSeparados[0])
                        {
                            //Se verifica si el primer dato de la cadena recibida es Conexion
                            case "Conexion":
                                //Si cumple entra y se ejecuta lo siguiente:
                                //Mostramos un mensaje de aceptación de conexión

                                Console.WriteLine("El servidor ha aceptado a un cliente..." + manejoCliente.Client.RemoteEndPoint);
                                //Mensaje de usuario recibido
                                Console.WriteLine("Usuario recibido");
                                //Se muestra en consola el nombre del usuario conectado
                                Console.WriteLine("Usuario: {0}{1}{2}{3}", datosSeparados);
                                break;

                            case "Crear":
                               //Se muestra mensaje de canción creada
                                //Console.WriteLine("Se ha creado una cancio");
                                //Mostramos en consola los datos colocados por el cliente
                                //para la nueva canción
                                Console.WriteLine("Datos guardados en la BDD");
                                Console.WriteLine("Nombre: {1}", datosSeparados);
                                Console.WriteLine("Apellido: {2}", datosSeparados);
                                Console.WriteLine("Cedula: {3}", datosSeparados);
                                Console.WriteLine("DireccionIP:" + manejoCliente.Client.RemoteEndPoint);
                                //Console.WriteLine("Clasificacion: {5}", datosSeparados);
                                //Instanciamos objeto cancion con los datos puestos por el cliente
                               // Usuario us = new Usuario(datosSeparados[1], datosSeparados[2],
                                 //  datosSeparados[3],Convert.ToString(manejoCliente.Client.RemoteEndPoint));
                                //Creamos objeto del manejadorDB
                               ConexionDB manejadorDatos1 = new ConexionDB();
                                //Ejecutamos método CrearCancion de la clase manejadorDB, colocamos como parametro
                                //el objeto Cancion creado con los datos puestos por el cliente
                                manejadorDatos1.Insertar(datosSeparados[1], datosSeparados[2],
                                   datosSeparados[3], Convert.ToString(manejoCliente.Client.RemoteEndPoint));

                                break;

                            case "Pedido de horario":

                                break;

                            case "Pedido de salvoconducto":

                                //Se muestra mensaje de canción creada
                                //Console.WriteLine("Se ha creado una cancio");
                                //Mostramos en consola los datos colocados por el cliente
                                //para la nueva canción
                                Console.WriteLine("Datos guardados en la BDD");
                                Console.WriteLine("Placa: {1}", datosSeparados);
                                Console.WriteLine("Cedula: {2}", datosSeparados);
                                                               
                                ConexionDB manejadorDatos = new ConexionDB();
                                //Ejecutamos método CrearCancion de la clase manejadorDB, colocamos como parametro
                                //el objeto Cancion creado con los datos puestos por el cliente
                                manejadorDatos.salvoconducto(datosSeparados[1], datosSeparados[2]);
                                //Console.WriteLine(manejadorDatos.salvoconducto(datosSeparados[1], datosSeparados[2]));
                                break;


                            case "mostrarHorario":

                                //Se muestra mensaje de canción creada
                                //Console.WriteLine("Se ha creado una cancio");
                                //Mostramos en consola los datos colocados por el cliente
                                //para la nueva canción
                                Console.WriteLine("Datos guardados en la BDD");
                                Console.WriteLine("Placa: {1}", datosSeparados);
                                Console.WriteLine("Cedula: {2}", datosSeparados);

                                ConexionDB manejadorDatos3 = new ConexionDB();
                                //Ejecutamos método CrearCancion de la clase manejadorDB, colocamos como parametro
                                //el objeto Cancion creado con los datos puestos por el cliente
                                manejadorDatos3.horario(datosSeparados[1], datosSeparados[2]);
                                //Console.WriteLine(manejadorDatos.salvoconducto(datosSeparados[1], datosSeparados[2]));
                                break;
                        }

                    }
                   
                } while (datosLeidos > 0); //Todo se ejecutará una vez, mientras se reciban datos
            }
        }
    }
}
