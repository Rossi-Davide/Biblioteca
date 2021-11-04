using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaSoftware
{
    public class Utente: IComparable<Utente>, IEquatable<Utente>
    {
        public string Nome { set; get; }

        public string Cognome { set; get; }

        public string Citta { set; get; }

        public string Cap { set; get; }

        public string Telefono { set; get; }

        private DateTime _nascita;

        public DateTime Nascita
        {
            set
            {
                if (value.Year < 1900|| value> DateTime.Now)
                {
                    throw new Exception("Inserire una data di nascita valida");
                }

                _nascita = value;
            }

            get
            {
                return _nascita;
            }
        }

        public string Indirizzo { set; get; }

        public List<Libro> LibriUt { set; get; }

        public Utente(string nome, string cognome, string citta, string cap, string telefono, DateTime nascita,string indirizzo) 
        {
            Nome = nome;
            Cognome = cognome;
            Citta = citta;
            Cap = cap;
            Telefono = telefono;
            Nascita= nascita;
            LibriUt = new List<Libro>();
            Indirizzo = indirizzo;
        }

        public int CompareTo(Utente other)
        {
            if(Cognome.CompareTo(other.Cognome) == 0)
            {
                return  Nome.CompareTo(other.Nome);
            }

            return Cognome.CompareTo(other.Cognome);
        }

        public bool Equals(Utente other)
        {
            if (Nome == other.Nome && Cognome == other.Cognome && Citta == other.Citta && Cap == other.Cap && Telefono == other.Telefono && Nascita == other.Nascita && Indirizzo == other.Indirizzo)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return Nome + " "+Cognome;
        }
    }
}
