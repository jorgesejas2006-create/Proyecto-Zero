using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace sing_up
{
    public partial class MainWindow : Window
    {
        private readonly string rutaYnombreArch = "c:\\datosUsuario\\datosUsr.txt";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtgmail.Text) || string.IsNullOrWhiteSpace(pwdpas.Password))
            {
                lblMensajes.Content = "Debe ingresar todos los datos";
                lblMensajes.Foreground = Brushes.Red;
                return;
            }

            try
            {
                string email = txtgmail.Text.Trim();
                string contra = pwdpas.Password.Trim();


                if (!File.Exists(rutaYnombreArch))
                {
                    lblMensajes.Foreground = Brushes.Red;
                    lblMensajes.Content = "La ruta o nombre del archivo no existen!!";
                    return;
                }


                var lineas = File.ReadAllLines(rutaYnombreArch);
                bool encontrado = false;

                foreach (var unaLinea in lineas)
                {

                    if (string.IsNullOrWhiteSpace(unaLinea))
                        continue;


                    var partes = unaLinea.Split(',');

                    if (partes.Length < 5)
                        continue;

                    string nombreCompleto = partes[0].Trim();
                    string emailArchivo = partes[1].Trim();
                    string celular = partes[2].Trim();
                    string año = partes[3].Trim();
                    string passwordArchivo = partes[4].Trim();
                    if (email.Equals(emailArchivo, StringComparison.OrdinalIgnoreCase)
                        && contra.Equals(passwordArchivo))
                    {
                        encontrado = true;
                        break;
                    }
                }

                if (encontrado)
                {
                    lblMensajes.Content = "Bienvenido al sistema NN...";
                    lblMensajes.Foreground = Brushes.Black;

                    WindowPrincipal principal = new WindowPrincipal();
                    principal.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("USUARIO NO AUTORIZADO...");
                    txtgmail.Clear();
                    pwdpas.Clear();
                    lblMensajes.Foreground = Brushes.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer el archivo: " + ex.Message);
            }
        }

        private void btnLinpiar_Click(object sender, RoutedEventArgs e)
        {
            txtgmail.Clear();
            pwdpas.Clear();
            lblMensajes.Content = "";
        }

        private void txtgmail_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regexEmail = new Regex("^[a-zA-Z0-9@.]$");
            e.Handled = !regexEmail.IsMatch(e.Text);
        }

        private void btnRegistro_Click(object sender, RoutedEventArgs e)
        {
            WinsingUP winsingnup = new WinsingUP();
            winsingnup.Show();
            this.Close();
        }
    }
}
