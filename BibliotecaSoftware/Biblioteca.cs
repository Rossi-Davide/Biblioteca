using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BibliotecaSoftware
{
    public  class Biblioteca
    {
        public string Nome { set; get; }

        public List<Utente> Utenti { set; get; }

        public List<Libro> LibriBib { set; get; }

        private string _path;

        public Biblioteca(string path)
        {

            Utenti = new List<Utente>();

            LibriBib = new List<Libro>();

            _path = path;

            Lettura();
        }

        private void Lettura()
        {
            if (_path == null)
            {
                throw new Exception("Per continuare è per forza richiesto un percorso");
            }

            using (StreamReader sr= new StreamReader(_path))
            {
                string linea;

                while((linea = sr.ReadLine()) != null)
                {
                    string[] elementi = linea.Split('|');

                    elementi[0] = elementi[0].ToLower();

                    if (elementi[0]=="b")
                    {
                        LetturaBiblioteca(elementi);
                    }
                    else if (elementi[0] == "u")
                    {
                        LetturaUtenti(elementi);
                    }
                    else
                    {
                        throw new Exception("TIpo di oggetto non riconosciuto");
                    }
                }
            }
        }


        private void LetturaBiblioteca(string[] elementi)
        {
            Nome = elementi[1];
        }


        private void LetturaUtenti(string[] elementi)
        {
            

            try
            {
                long.Parse(elementi[5]);
            }catch(Exception ex)
            {
                throw new Exception("Il parametro numero di telefono può contenere solo numeri");
            }

            DateTime nascita;
            try
            {
                nascita = DateTime.Parse(elementi[6]);
            }
            catch (Exception ex)
            {
                throw new Exception("Errore nella lettura della data");
            }

            Utente utente = new Utente(elementi[1],elementi[2],elementi[3],elementi[4],elementi[5],nascita,elementi[7]);

            Utenti.Add(utente);
        }

        public List<Utente> Search(bool nome,bool cognome, bool data,string cerca)
        {
            List<Utente> matches =new List<Utente>();

            foreach(Utente utente in Utenti)
            {
                if (nome)
                {
                    if (utente.Nome == cerca)
                    {
                        matches.Add(utente);
                    }
                }

                if (cognome)
                {
                    if (utente.Cognome == cerca)
                    {
                        matches.Add(utente);
                    }
                }

                if (data)
                {
                    if(utente.Nascita.Date.ToString() == cerca)
                    {
                        matches.Add(utente);
                    }
                }
            }

            return matches;
        }

        public void Scrittura()
        {
            using(StreamWriter sr = new StreamWriter(_path))
            {
                string linea;

                //Scrittura biblioteca

                linea = "b|" + Nome;

                sr.WriteLine(linea);

                foreach(Utente u in Utenti)
                {
                    linea = ScritturaUtenti(u);

                    sr.WriteLine(linea);
                }
            }
        }

        private string ScritturaUtenti(Utente u)
        {
            string utenteString = "";

            utenteString += "u|";

            utenteString += u.Nome + "|";

            utenteString += u.Cognome + "|";

            utenteString += u.Citta + "|";

            utenteString += u.Cap + "|";

            utenteString += u.Telefono + "|";

            utenteString += u.Nascita + "|";

            utenteString += u.Indirizzo;

            return utenteString;
        }
    }
}
