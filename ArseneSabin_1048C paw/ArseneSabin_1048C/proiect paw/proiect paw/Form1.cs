using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace proiect_paw
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        public Form1(string nume, string prenume)
        {
            InitializeComponent();

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear(); 

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "Introduceți nume!");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                errorProvider1.SetError(textBox2, "Selectați prenume!");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                errorProvider1.SetError(textBox3, "Introduceți CNP!");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                errorProvider1.SetError(textBox4, "Introduceți telefon!");
                return;
            }

            long CNP;
            if (!long.TryParse(textBox3.Text, out CNP))
            {
                errorProvider1.SetError(textBox3, "CNP-ul introdus este invalid!");
                return;
            }

        
            if (!IsValidCNP(textBox3.Text))
            {
                errorProvider1.SetError(textBox3, "CNP-ul introdus este invalid!");
                return;
            }

            long telefon;
            if (!long.TryParse(textBox4.Text, out telefon))
            {
                errorProvider1.SetError(textBox4, "Numărul de telefon introdus este invalid!");
                return;
            }

        
            if (!IsValidPhoneNumber(textBox4.Text))
            {
                errorProvider1.SetError(textBox4, "Numărul de telefon introdus este invalid!");
                return;
            }

         
            string nume = textBox1.Text;
            string prenume = textBox2.Text;
            string linie = $"Clientul {nume} {prenume} are CNP:{CNP} si telefon:{telefon}";
            string numeFisier = "persoane.txt";

            if (ClientExistsInFile(linie, numeFisier))
            {
                errorProvider1.SetError(textBox3, "Există deja un client cu același CNP!");
                errorProvider1.SetError(textBox4, "Există deja un client cu același număr de telefon!");
                return;
            }

           
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(numeFisier, true))
            {
                file.WriteLine(linie);
            }


           
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
          
            Form4 form4 = new Form4();

            
            form4.Show();
            this.Hide();
        }


        

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {  
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";

            }
            catch (Exception ex)
            {
                MessageBox.Show("ceva");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear(); 
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "Introduceți nume!");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                errorProvider1.SetError(textBox2, "Selectați prenume!");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                errorProvider1.SetError(textBox3, "Introduceți CNP!");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                errorProvider1.SetError(textBox4, "Introduceți telefon!");
                return;
            }

            long CNP;
            if (!long.TryParse(textBox3.Text, out CNP))
            {
                errorProvider1.SetError(textBox3, "CNP-ul introdus este invalid!");
                return;
            }

          
            if (!IsValidCNP(textBox3.Text))
            {
                errorProvider1.SetError(textBox3, "CNP-ul introdus este invalid!");
                return;
            }

            long telefon;
            if (!long.TryParse(textBox4.Text, out telefon))
            {
                errorProvider1.SetError(textBox4, "Numărul de telefon introdus este invalid!");
                return;
            }

  
            if (!IsValidPhoneNumber(textBox4.Text))
            {
                errorProvider1.SetError(textBox4, "Numărul de telefon introdus este invalid!");
                return;
            }

           
            string nume = textBox1.Text;
            string prenume = textBox2.Text;
            string linie = $"Clientul {nume} {prenume} are CNP:{CNP} si telefon:0{telefon}";
            string numeFisier = "persoane.txt";
          
          
            
            //Form3 form3 = new Form3();

            Form2 form2 = new Form2(nume, prenume, CNP, telefon);
            Form3 form3 = new Form3();

            form3.Show();
            this.Hide();

            if (ClientExistsInFile(linie, numeFisier))
            {
                errorProvider1.SetError(textBox3, "Există deja un client cu același CNP!");
                errorProvider1.SetError(textBox4, "Există deja un client cu același număr de telefon!");
                return;
            }

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(numeFisier, true))
            {
                file.Write(linie);
            }

           
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            errorProvider1.Clear(); 

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                errorProvider1.SetError(textBox1, "Introduceți nume!");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                errorProvider1.SetError(textBox2, "Selectați prenume!");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                errorProvider1.SetError(textBox3, "Introduceți CNP!");
                return;
            }

            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                errorProvider1.SetError(textBox4, "Introduceți telefon!");
                return;
            }

            long CNP;
            if (!long.TryParse(textBox3.Text, out CNP))
            {
                errorProvider1.SetError(textBox3, "CNP-ul introdus este invalid!");
                return;
            }

            if (!IsValidCNP(textBox3.Text))
            {
                errorProvider1.SetError(textBox3, "CNP-ul introdus este invalid!");
                return;
            }

            long telefon;
            if (!long.TryParse(textBox4.Text, out telefon))
            {
                errorProvider1.SetError(textBox4, "Numărul de telefon introdus este invalid!");
                return;
            }

            if (!IsValidPhoneNumber(textBox4.Text))
            {
                errorProvider1.SetError(textBox4, "Numărul de telefon introdus este invalid!");
                return;
            }

          
            string nume = textBox1.Text;
            string prenume = textBox2.Text;
            string linie = $"Clientul {nume} {prenume} are CNP:{CNP} si telefon:{telefon}";
            string numeFisier = "persoane.txt";

            if (ClientExistsInFile(linie, numeFisier))
            {
                errorProvider1.SetError(textBox3, "Există deja un client cu același CNP!");
                errorProvider1.SetError(textBox4, "Există deja un client cu același număr de telefon!");
                return;
            }

            // Salvarea în fișier text
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(numeFisier, true))
            {
                file.WriteLine(linie);
            }

            MessageBox.Show("Datele au fost salvate cu succes în fișier!");

         
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }


        private bool ClientExistsInFile(string clientData, string fileName)
        {
            string[] existingClients = System.IO.File.ReadAllLines(fileName);

            foreach (string client in existingClients)
            {
                string[] clientInfo = client.Split(',');

                if (clientInfo.Length >= 4)
                {
                    string existingCNP = clientInfo[2];
                    string existingPhoneNumber = clientInfo[3];

                    if (clientData.Contains(existingCNP) || clientData.Contains(existingPhoneNumber))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool IsValidCNP(string cnp)
        {
            string pattern = @"^[1-9]\d{2}(0[1-9]|1[0-2])(0[1-9]|[12]\d|3[01])(0[1-9]|[1-4]\d|5[0-2]|99)(00[1-9]|0[1-9]\d|[1-9]\d\d)\d$";
            return Regex.IsMatch(cnp, pattern);
        }


        private bool IsValidPhoneNumber(string phoneNumber)
        {
            string pattern = @"^[0-9]{10}$";
            return Regex.IsMatch(phoneNumber, pattern);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fisier formFisier = new fisier();

            try
            {
                string[] linii = System.IO.File.ReadAllLines("persoane.txt");
                formFisier.AfiseazaDate(linii);
                formFisier.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("A apărut o eroare la citirea datelor din fișier: " + ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Doriți să închideți aplicația?", "Închidere aplicație", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Close();
        }
    }
}
