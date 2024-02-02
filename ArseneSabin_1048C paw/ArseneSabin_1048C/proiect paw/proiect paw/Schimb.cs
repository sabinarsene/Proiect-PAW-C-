using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect_paw
{
    public class Schimb:Client
    {
        private float suma;
        private string valutaI;
        private string valutaO;

        public Schimb(string nume, string prenume, int cnp, int telefon, float suma, string valutaI, string valutaO): base(nume, prenume, cnp, telefon)
        {
            this.suma = suma;
            this.valutaI = valutaI;
            this.valutaO = valutaO;
        }

        public float Suma { get => suma; set => suma = value; }
        public string ValutaI { get => valutaI; set => valutaI = value; }
        public string ValutaO { get => valutaO; set => valutaO = value; }
    }


}
