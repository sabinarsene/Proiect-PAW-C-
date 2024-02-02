using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proiect_paw
{
    internal class Send:Client
    {
        private float sumaP;
        private string tip;
        private string numeP;
        private int cnpP;
        private int telefonP;
        private string ibanP;

        public Send():base()
        {
            tip = "euro";
            sumaP = 0;
            numeP = "na";
            cnpP = 0;
            telefonP = 0;
            ibanP = "na";
        }

        public Send(string nume, string prenume, int cnp, int telefon, string numeP, int cnpP, int telefonP, string ibanP, int sumaP, string tip) 
            : base(nume, prenume, cnp, telefon)
        {
            this.tip = tip;
            this.sumaP = sumaP;
            this.numeP = numeP;
            this.cnpP = cnpP;
            this.telefonP = telefonP;
            this.ibanP = ibanP;

        }

        public string NumeP { get => numeP; set => numeP = value; }
        public int CnpP { get => cnpP; set => cnpP = value; }
        public int TelefonP { get => telefonP; set => telefonP = value; }
        public string IbanP { get => ibanP; set => ibanP = value; }
        public float SumaP { get => sumaP; set => sumaP = value; }
        public string Tip { get => tip; set => tip = value; }

        public override string ToString()
        {
            return "Suma de " + sumaP + " " + tip + " a fost virata catre " + numeP + " cu CNP ul " 
                + cnpP + " si numarul " + telefonP + " in contul " + ibanP;
        }




    }
}
