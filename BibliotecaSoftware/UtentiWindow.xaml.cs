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
using System.Windows.Shapes;

namespace BibliotecaSoftware
{
    /// <summary>
    /// Interaction logic for UtentiWindow.xaml
    /// </summary>
    public partial class UtentiWindow : Window
    {
        Biblioteca _biblioteca;
        bool editMode = false;

        public UtentiWindow(Biblioteca biblioteca)
        {
            InitializeComponent();

            _biblioteca = biblioteca;
            utentiLi.Items.Clear();
            utentiLi.ItemsSource = _biblioteca.Utenti;
        }

        private void searchB_Click(object sender, RoutedEventArgs e)
        {
            bool cognome = cognomeCh.IsEnabled;
            bool nome = nomeCh.IsEnabled;
            bool data = dataCh.IsEnabled;

            utentiLi.Items.Clear();

            utentiLi.ItemsSource = _biblioteca.Search(nome, cognome, data, searchT.Text);
        }

        private void aggiungiB_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DateTime nascita;

                try
                {
                     nascita = DateTime.Parse(nascitaT.Text);
                }
                catch(Exception ex)
                {
                    throw new Exception("Parametri non inseriti correttamente");
                }
                

                Utente utente = new Utente(nomeT.Text,cognomeT.Text,cittaT.Text,capT.Text,telefonoT.Text,nascita,indirizzoT.Text);

                _biblioteca.Utenti.Add(utente);

                utentiLi.ItemsSource = null;
                utentiLi.ItemsSource = _biblioteca.Utenti;

                _biblioteca.Scrittura();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void modificaB_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(utentiLi.SelectedItem == null)
                {
                    throw new Exception("Nessun elemento selezionato");
                }

                Utente utenteEdit = (Utente)utentiLi.SelectedItem;

                nomeT.Text = utenteEdit.Nome;
                cognomeT.Text = utenteEdit.Cognome;
                cittaT.Text = utenteEdit.Citta;
                capT.Text = utenteEdit.Cap;
                telefonoT.Text = utenteEdit.Telefono;
                nascitaT.Text = utenteEdit.Nascita.ToString();
                indirizzoT.Text = utenteEdit.Indirizzo;
                editMode = true;

                

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void confermaB_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!editMode)
                {
                    throw new Exception("Non si è in modalità di modifica");
                }

                if (utentiLi.SelectedItem == null)
                {
                    throw new Exception("Nessun elemento selezionato");
                }

                Utente utenteEdit = (Utente)utentiLi.SelectedItem;

                utenteEdit.Nome = nomeT.Text;
                utenteEdit.Cognome = cognomeT.Text;
                utenteEdit.Citta = cittaT.Text;
                utenteEdit.Cap = capT.Text;
                utenteEdit.Telefono = telefonoT.Text;
                utenteEdit.Indirizzo = indirizzoT.Text;

                DateTime nascita;

                try
                {
                    nascita = DateTime.Parse(nascitaT.Text);
                }
                catch (Exception ex)
                {
                    throw new Exception("Data non inserita correttamente");
                }

                utenteEdit.Nascita = nascita;

                utentiLi.ItemsSource = null;
                utentiLi.ItemsSource = _biblioteca.Utenti;

                editMode = false;

                _biblioteca.Scrittura();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void eliminaB_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (utentiLi.SelectedItem == null)
                {
                    throw new Exception("Nessun elemento selezionato");
                }

                Utente utenteEdit = (Utente)utentiLi.SelectedItem;

                _biblioteca.Utenti.Remove(utenteEdit);

                utentiLi.ItemsSource = null;
                utentiLi.ItemsSource = _biblioteca.Utenti;

                _biblioteca.Scrittura();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
