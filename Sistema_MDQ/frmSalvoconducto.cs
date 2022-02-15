using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using Clases;

namespace Sistema_MDQ
{
    public partial class frmSalvoconducto : Form
    {
        public frmSalvoconducto()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Verifique que se digito un motivo", "Error en ingreso de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                string cedula;
                //Creamos punto final de conexión con dirección de loopback y puerto 11000
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
                    //Instanciamos un objeto del tipo frmPrincipal
                    //frmRegistro menu = new frmRegistro();
                    //cedula = menu.txtNumCedula.Text;
                    cedula = "40012823";
                    //Declaramos arreglo de bytes para almacenar los datos codificados
                    byte[] bufferTx = Encoding.ASCII.GetBytes("conexion;" + maskedTextBox1.Text + ";" + cedula);
                    //Creamos objeto de la clase GestorCancion

                    Cliente plac = new Cliente();

                    //Ejecutamos método Crear de la clase GestorCancion
                    plac.enviarPlaca(maskedTextBox1.Text, cedula);
                    //Escribimos los bytes obtenidos en el flujo de red
                    flujo.Write(bufferTx, 0, bufferTx.Length);
                    //Cerramos comunicación
                    cliente.Close();
                }*/
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void verHorario_Click(object sender, EventArgs e)
        {
            //capturamos datos
            string cedula;
            string placa;
            cedula = "17514288";
            placa = "ABC-7894";


            //Creamos punto final de conexión con dirección de loopback y puerto 11000
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
                //Instanciamos un objeto del tipo frmPrincipal
                //frmRegistro menu = new frmRegistro();
                //cedula = menu.txtNumCedula.Text;
                cedula = "40012823";
                //Declaramos arreglo de bytes para almacenar los datos codificados
                byte[] bufferTx = Encoding.ASCII.GetBytes("conexion;" + placa + ";" + cedula);
                //Creamos objeto de la clase GestorCancion

                Cliente hor = new Cliente();

                //Ejecutamos método Crear de la clase GestorCancion
                hor.verHorario(placa, cedula);
                //Escribimos los bytes obtenidos en el flujo de red
                flujo.Write(bufferTx, 0, bufferTx.Length);
                //Cerramos comunicación
                cliente.Close();

          

            }
            else
            {
                //Mostramos mensaje de conexión fallida
                MessageBox.Show("La conexión falló", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        

        }
    }
}
