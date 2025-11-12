using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.IO;

namespace sing_up
{
    /// <summary>
    /// Lógica de interacción para WinsingUP.xaml
    /// </summary>
    public partial class WinsingUP : Window
    {
        private readonly string rutaYnombreArch = "c:\\datosUsuario\\datosUsr.txt";
        public WinsingUP()
        {
            InitializeComponent();
        }
        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            int anio;
            anio = int.Parse(txtAño.Text);
            if (anio <= 1950 || anio > 2007)
            {
                txtAño.Text = "";
            }
            if (txtNombre.Text == "" || txtapPaterno.Text == "" || txtapMaterno.Text == "" || txtgmail.Text ==""  || txtapcelular.Text == "" || pwdpas.Password == "" || txtAño.Text == "")
            {
                lblMensajes.Content = "Debe completar TODOS los datos";
                lblMensajes.Foreground = Brushes.White;
            }
            else
            {
                
                try
                {
                    lblMensajes.Content = "Bienvenido al sistema NN" + txtNombre.Text + "...";
                    lblMensajes.Foreground = Brushes.Black;
                    string datos = txtNombre.Text + "  " + txtapPaterno.Text + "  " + txtapMaterno.Text + "," + txtgmail.Text +
                        "," + txtapcelular.Text + "," + txtAño.Text + "," + pwdpas.Password + "\n";
                    File.AppendAllText(rutaYnombreArch, datos);
                    lblMensajes.Content = "Bienvenido al sistema NN" + "...";
                    lblMensajes.Foreground = Brushes.Black;
                    WindowPrincipal winP = new WindowPrincipal();
                    winP.Show();
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el archivo " + ex.Message);
                }
            }
        }

        private void btnLinpiar_Click(object sender, RoutedEventArgs e)
        {
            txtNombre.Clear();
            txtapPaterno.Clear();
            txtapMaterno.Clear();
            txtgmail.Clear();
            txtapcelular.Clear();   
            txtAño.Clear();
            pwdpas.Password="";
        }
        private void txtgmail_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regexEmail = new Regex("^[a-zA-Z0-9@.]$");
            e.Handled = !regexEmail.IsMatch(e.Text);
        }

        private void txtapcelular_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regexCelular = new Regex("^[0-9-+]$");
            e.Handled = !regexCelular.IsMatch(e.Text);
        }

        private void txtAño_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regexCelular = new Regex("^[0-9]$");
            e.Handled = !regexCelular.IsMatch(e.Text);
        }

       
    }
}

//int anio;
//anio = int.Parse(txtAño.Text);
//if (anio > 1950 && anio <= 2007)
//{
//    txtAño.Text = "";
//}