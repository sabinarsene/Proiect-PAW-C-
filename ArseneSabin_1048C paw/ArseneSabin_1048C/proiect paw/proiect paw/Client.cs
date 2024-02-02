using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace proiect_paw
{
    public class Client
    { 
        private string nume;
        private string prenume;
        private int cnp;
        private int telefon;

        public Client()
        {
            nume = "na";
            prenume = "na";
            cnp = 0;    
            telefon = 0;
        }

        public Client(string nume, string prenume, int cnp, int telefon)

        {
            this.nume = nume;
            this.prenume = prenume;
            this.cnp = cnp;
            this.telefon = telefon;
        }

        public string Nume { get => nume; set => nume = value; }
        public string Prenume { get => prenume; set => prenume = value; }
        public int CNP { get => cnp; set => cnp = value; }
        public int Telefon { get => telefon; set => telefon = value; }

        public override string ToString()
        {
            return nume+ " " + prenume+ "\nare CNP " + cnp + " si telefonul " + telefon;
        }
    }
}
