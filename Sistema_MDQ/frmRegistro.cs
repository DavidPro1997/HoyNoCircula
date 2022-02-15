using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Clases;

namespace Sistema_MDQ
{
    
    public partial class frmRegistro : Form
    {
     
        //Constructor del formulario
        public frmRegistro()
        {
            //Se inician los componentes del formulario
            InitializeComponent();
        }

        //Evento click para boton ingresar/conectar
     
        private void btnIngresar_Click_1(object sender, EventArgs e)
        {
            //Verifica que los valores de los textbox no esten vacios

            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("Verifique que se digito un nombre", "Error en ingreso de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (string.IsNullOrEmpty(txtNumCedula.Text))
            {
                MessageBox.Show("Verifique que se ingreso correctamente una cédula", "Error en ingreso de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (string.IsNullOrEmpty(txtApellido.Text))
            { 
                MessageBox.Show("Verifique que se ingreso correctamente el apellido", "Error en ingreso de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            else
            { //Creamos punto final de conexión con dirección de loopback y puerto 11000
                IPEndPoint remoto = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 11000);
                //Creamos cliente TCP
                TcpClient cliente = new TcpClient();
                //Establecemos la conexión a través del punto final creado
                cliente.Connect(remoto);
                //Verificamos si existe conectividad
                if (cliente.Connected)
                {
                    //Creamos flujo de red
                    NetworkStream flujo = cliente.GetStream();
                    //Declaramos arreglo de bytes para almacenar los datos codificados
                    byte[] bufferTx = Encoding.ASCII.GetBytes("Conexion;" + txtNombre.Text +  ";" + txtApellido.Text + ";" + txtNumCedula.Text);
                    //Creamos objeto de la clase GestorCancion

                    Cliente us = new Cliente();

                    //Creamos objeto de la clase Cancion y colocamos datos ingresados por el cliente 
                    Usuario usuario = new Usuario(txtNumCedula.Text, txtNombre.Text, txtApellido.Text, Convert.ToString(cliente.Client.RemoteEndPoint));
                    //Ejecutamos método Crear de la clase GestorCancion
                    us.Ingresar(usuario);
                    //Escribimos los bytes obtenidos en el flujo de red
                    flujo.Write(bufferTx, 0, bufferTx.Length);
                    //Cerramos comunicación
                    cliente.Close();

                    //Instanciamos un objeto del tipo frmPrincipal
                    frmPrincipal menu = new frmPrincipal();
                    //Mostramos formulario de menu de usuario
                    this.Hide();
                    menu.txtnombre.Text = txtNumCedula.Text;
                    menu.ShowDialog();
                    this.Close();
                  
                
                }
                else
                {
                    //Mostramos mensaje de conexión fallida
                    MessageBox.Show("La conexión falló", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

          
        
        }
    }
}
