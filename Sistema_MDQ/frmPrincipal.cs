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
    public partial class frmPrincipal : Form
    {
        private bool placa = false;
        private bool fecha = false;
        private bool hora = false;
        private int ubicacion = 0;
        private string provincia;
        private int segunda = 0;
        private int digito = 0;
        private string circula;
        private string color;
        private string dia;
        private string mes;

        public frmPrincipal()
        {
            InitializeComponent();
        }

     

        private void txtFecha_Leave_1(object sender, EventArgs e)
        {
            try
            {
                DateTime dias = new DateTime(Convert.ToInt32(txtFecha.Text.Substring(6, 4)), Convert.ToInt32(txtFecha.Text.Substring(3, 2)), Convert.ToInt32(txtFecha.Text.Substring(0, 2)));
                digito = (int)dias.DayOfWeek;
                dia = dias.ToString("dddd");
                mes = dias.ToString("MMMM");
                fecha = true;
            }
            catch (Exception)
            {
                MessageBox.Show("La fecha ingresada es invalida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                fecha = false;
            }
        }

        private void LoadUserData()
        {

            //lbl_tipo_de_usuario.Content = Usuario_cache.NombreLog;
         
        }


        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            //Verifica que los valores de los textbox no esten vacios
            
            if (string.IsNullOrEmpty(maskedTextBox1.Text))
            {
                MessageBox.Show("Verifique que se digito una placa", "Error en ingreso de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    
                    /*            
                 //Instanciamos un objeto del tipo frmSalvoCOnducto
                 frmSalvoconducto menu = new frmSalvoconducto();

                 //Mostramos formulario de menu de usuario
                 this.Hide();

                 menu.ShowDialog();
                 this.Close();
                 */

                }
                else 
                {
                    //Mostramos mensaje de conexión fallida
                    MessageBox.Show("La conexión falló", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }



        }

        private void button1_Click(object sender, EventArgs e)
        {


            //Verifica que los valores de los textbox no esten vacios

            if (string.IsNullOrEmpty(maskedTextBox1.Text))
            {
                MessageBox.Show("Verifique que se digito una placa", "Error en ingreso de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                //Instanciamos un objeto del tipo frmSalvoCOnducto
                frmSalvoconducto menu = new frmSalvoconducto();

                //Mostramos formulario de menu de usuario
                this.Hide();
                
                menu.ShowDialog();
                this.Close();
                


            }




        }
    }
}
