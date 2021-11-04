using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaSoftware
{
    public class Copia: IEquatable<Copia>, IComparable<Copia>
    {
        private string _stato;

        public string Stato 
        {

            set
            {
                value = value.ToLower();

                if(value!= "prestito" && value != "disponibile")
                {
                    throw new Exception("Stato della copia non valido");
                }

                _stato = value;
            }

            get
            {
                return _stato;
            }
        
        }

        public string Codice { set; get; }

        private double _prezzo;

        public double Prezzo
        {
            set
            {
                if (value < 0)
                {
                    throw new Exception("Il prezzo noon può essere inferiore a 0");
                }

                _prezzo = value;
            }

            get
            {
                return _prezzo;
            }
        }

        public string ISBN { set; get; }

        public string CasaEd { set; get; }

        private DateTime _acquisizione;

        public DateTime Acquisizione
        {
            set
            {
                if(value.Year<1900 || value> DateTime.Now)
                {
                    throw new Exception("Inserire una data valida");
                }

                _acquisizione = value;
            }

            get
            {
                return _acquisizione;
            }
        }

        public Copia(string stato,string codice,double prezzo,string ISBN,string casaEd,DateTime acquisizione)
        {
            Stato = stato;
            Codice = codice;
            Prezzo = prezzo;
            this.ISBN = ISBN;
            CasaEd = casaEd;
            Acquisizione = acquisizione;
        }

        public int CompareTo(Copia other)
        {
            return Codice.CompareTo(other.Codice);
        }

        public bool Equals(Copia other)
        {
            if(Codice == other.Codice)
            {
                return true;
            }

            return false;
        }
    }
}
