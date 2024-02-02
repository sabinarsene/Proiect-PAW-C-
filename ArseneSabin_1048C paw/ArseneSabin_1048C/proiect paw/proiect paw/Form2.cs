using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace proiect_paw
{
    public partial class Form2 : Form
    {
        private PrintPreviewDialog printPreviewDialog;
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public long CNP { get; set; }
        public long Telefon { get; set; }
        private string to;
        private string cnp;
        private string telefonC;
        private float suma;
        private string valuta;
        private string iban;

        public Form2()
        {
            InitializeComponent();
            printPreviewDialog = new PrintPreviewDialog();
        }

        public Form2(string nume, string prenume, decimal CNP, long telefon)
        {
            InitializeComponent();
            //printPreviewDialog = new PrintPreviewDialog();
            this.Nume = nume;
            this.Prenume = prenume;
            this.CNP = (long)CNP;
            this.Telefon = telefon;
        }

        public Form2(string to, string cnp, string telefonC, float suma, string valuta, string iban)
        {
            InitializeComponent();
            this.to = to;
            this.cnp = cnp;
            this.telefonC = telefonC;
            this.suma = suma;
            this.valuta = valuta;
            this.iban = iban;
        }


        private void button1_Click(object sender, EventArgs e)
        {

            PrintDocument printDocument = new PrintDocument();

       
            printDocument.PrintPage += PrintDocument_PrintPage;

            
            //PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;

            // previzualizarea  printare
            printPreviewDialog.ShowDialog();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            // afișarea conținutului fișierului
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // fontul și formatul de text
            Font font = new Font("Arial", 12);
            StringFormat stringFormat = new StringFormat();

        
            float y = 100;
            float interliniu = 20;

            //  titlul
            e.Graphics.DrawString("DOVADA PLATII", new Font("Arial", 35, FontStyle.Bold), Brushes.Black, new PointF(250, y), stringFormat);


            y += interliniu * 10;
            //  informațiile din Form1


            e.Graphics.DrawString("Nume: " + Nume, font, Brushes.Black, new PointF(50, y), stringFormat);
            y += interliniu;
            e.Graphics.DrawString("Prenume: " + Prenume, font, Brushes.Black, new PointF(50, y), stringFormat);
            y += interliniu;
            e.Graphics.DrawString("CNP (Client): " + CNP.ToString(), font, Brushes.Black, new PointF(50, y), stringFormat);
            y += interliniu;
            e.Graphics.DrawString("Telefon (Client): 0" + Telefon.ToString(), font, Brushes.Black, new PointF(50, y), stringFormat);


            // Desenați informațiile din Form3
            y += interliniu * 2;
            e.Graphics.DrawString("To: " + to, font, Brushes.Black, new PointF(50, y), stringFormat);
            y += interliniu;
            e.Graphics.DrawString("CNP (Primitor): " + cnp, font, Brushes.Black, new PointF(50, y), stringFormat);
            y += interliniu;
            e.Graphics.DrawString("Telefon (Primitor): 0" + telefonC, font, Brushes.Black, new PointF(50, y), stringFormat);
            y += interliniu;
            e.Graphics.DrawString("Suma (Primitor): " + suma.ToString("N2") + " " + valuta, font, Brushes.Black, new PointF(50, y), stringFormat);
            y += interliniu;
            e.Graphics.DrawString("IBAN: " + iban, font, Brushes.Black, new PointF(50, y), stringFormat);
            y += interliniu * 10;
            e.Graphics.DrawString("Semnatură ", font, Brushes.Black, new PointF(50, y), stringFormat);
            e.Graphics.DrawString("Semnatură casier", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, new PointF(600, y), stringFormat);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Doriți să închideți aplicația?", "Închidere aplicație", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
