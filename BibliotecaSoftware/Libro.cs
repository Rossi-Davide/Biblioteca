using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaSoftware
{
   

    public class Libro: IEquatable<Libro>, IComparable<Libro>
    {
        public string Nome { set; get; }

        public List<string> Autori { set; get; }

        public string Id { set; get; }

        private int _nCopie; 

        public int NCopie
        {
            set
            {
                if (value < 0)
                {
                    throw new Exception("Il numero di copie non può essere inferiore a 0");
                    
                }

                _nCopie = value;
            }

            get
            {
                return _nCopie;
            }
        }

        public string Genere { set; get; }


        public List<Copia> Copie { set; get; }

        public Libro(string nome, List<string> autori, string id,int copie,string genere)
        {
            Nome = nome;
            Autori = autori;
            Id = id;
            Genere = genere;
            Copie = new List<Copia>();
        }

        public int CompareTo(Libro other)
        {
            return Id.CompareTo(other.Id);
        }

        public bool Equals(Libro other)
        {
            if (Id == other.Id)
            {
                return true;
            }

            return false;
        }
    }
}
