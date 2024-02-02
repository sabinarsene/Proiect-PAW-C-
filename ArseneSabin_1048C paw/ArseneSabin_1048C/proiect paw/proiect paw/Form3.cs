using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace proiect_paw
{
    public partial class Form3 : Form
    {



        private ErrorProvider errorProvider1;
        private string numeFisier = "persoane.txt";

        public Form3()     
        {
            InitializeComponent();
            

            // Inițializați ErrorProvider
            errorProvider1 = new ErrorProvider();
            errorProvider1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }


        private void button1_Click_1(object sender, EventArgs e)
        {

            string to = textBox2.Text;
            string cnp = textBox3.Text;
            string telefonC = textBox4.Text;
            string iban = textBox5.Text;
            float suma;
            string valuta = comboBox1.Text;

            bool isValidSuma = float.TryParse(textBox6.Text, out suma);
            if (!isValidSuma)
            {
                errorProvider1.SetError(textBox6, "Suma introdusă este invalidă!");
                return;
            }
            else
            {
                errorProvider1.SetError(textBox6, "");
            }

          
            if (!IsValidCNP(cnp))
            {
                errorProvider1.SetError(textBox3, "CNP-ul introdus este invalid!");
                return;
            }
            else
            {
                errorProvider1.SetError(textBox3, ""); // Clear error
            }

          
            if (!IsValidPhoneNumber(telefonC))
            {
                errorProvider1.SetError(textBox4, "Numărul de telefon introdus este invalid!");
                return;
            }
            else
            {
                errorProvider1.SetError(textBox4, ""); // Clear error
            }


            // Salvarea în fișier text
            string linie = $" a virat catre {to} in contul {iban} suma de {suma} {valuta} cu CNP: {cnp} și telefon: {telefonC}.";

            using (StreamWriter file = new StreamWriter(numeFisier, true))
            {
                file.WriteLine(linie);
            }


            Form2 form2 = new Form2(to, cnp, telefonC, suma, valuta, iban);
            form2.Show();
            this.Hide();

            // MessageBox.Show("Datele au fost adăugate cu succes!");

            
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();

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

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Doriți să închideți aplicația?", "Închidere aplicație", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
