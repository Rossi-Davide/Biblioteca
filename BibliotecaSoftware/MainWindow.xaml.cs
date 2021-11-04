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
using Microsoft.Win32;

namespace BibliotecaSoftware
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

//Inizio main window
    public partial class MainWindow : Window
    {
        Biblioteca _biblioteca;
        string path = null;

        public MainWindow()
        {
            InitializeComponent();

            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = ".txt|*.txt";

            if(ofd.ShowDialog()== true)
            {
                path = ofd.FileName;
            }

            try
            {
                _biblioteca = new Biblioteca(path);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           

            bibliotecaL.Content = _biblioteca.Nome;


        }

        private void UtentiB_Click(object sender, RoutedEventArgs e)
        {
            UtentiWindow utenti = new UtentiWindow(_biblioteca);

            utenti.ShowDialog();
        }
    }
}
