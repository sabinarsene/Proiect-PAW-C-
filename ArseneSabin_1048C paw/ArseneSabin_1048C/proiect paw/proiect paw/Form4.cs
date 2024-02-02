using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Data.OleDb;
using System.Net.NetworkInformation;
using System.Data;

namespace proiect_paw
{
    public partial class Form4 : Form
    {
        BindingSource  albumBindingSource=new BindingSource();
        private const string XmlFilePath = "nbrfxrates.xml";
        private const string ExchangeInfoFilePath = "exchange_info.xml";
        private const string PersoaneFilePath = "persoane.txt";
        private XmlDocument xmlDoc;
        private XmlNamespaceManager namespaceManager;
        private string currencyCode;
        private string exchangeCurrencyCode;

        public Form4()
        {
            InitializeComponent();
            xmlDoc = new XmlDocument();
            namespaceManager = new XmlNamespaceManager(xmlDoc.NameTable);
            namespaceManager.AddNamespace("bnr", "http://www.bnr.ro/xsd");
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            LoadCurrencyCodes();
        }

        private void LoadCurrencyCodes()
        {
            xmlDoc.Load(XmlFilePath);
            XmlNodeList currencyNodes = xmlDoc.SelectNodes("//bnr:Rate/@currency", namespaceManager);
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            foreach (XmlNode currencyNode in currencyNodes)
            {
                comboBox1.Items.Add(currencyNode.Value);
                comboBox2.Items.Add(currencyNode.Value);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            currencyCode = comboBox1.Text;
            exchangeCurrencyCode = comboBox2.Text;
            decimal rate = GetCurrencyRate(currencyCode);
            decimal exchangeRate = GetCurrencyRate(exchangeCurrencyCode);
            if (rate != -1 && exchangeRate != -1)
            {
                decimal sumaIntrodusa = decimal.Parse(textBox1.Text);
                decimal sumaConvertita = (sumaIntrodusa * exchangeRate) / rate;
                decimal comision = sumaConvertita * 0.05m;
                decimal sumaFinala = sumaConvertita + comision;
                textBox2.Text = sumaFinala.ToString("N2");

                SaveExchangeInformation(currencyCode, exchangeCurrencyCode, textBox1.Text, textBox2.Text);
                SaveToPersoaneFile(sumaIntrodusa.ToString(), currencyCode, textBox2.Text);
            }
            else
            {
                MessageBox.Show("Cursul valutar nu este disponibil.");
            }
        }

        private decimal GetCurrencyRate(string currencyCode)
        {
            xmlDoc.Load(XmlFilePath);
            XmlNode rateNode = xmlDoc.SelectSingleNode($"//bnr:Rate[@currency='{currencyCode}']", namespaceManager);
            if (rateNode != null && decimal.TryParse(rateNode.InnerText, out decimal rate))
            {
                return rate;
            }
            return -1;
        }

        private void SaveExchangeInformation(string currencyCode, string exchangeCurrencyCode, string textBox1Value, string textBox2Value)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(ExchangeInfoFilePath, true))
                {
                    writer.WriteLine($"Currency Code: {currencyCode}");
                    writer.WriteLine($"Exchange Currency Code: {exchangeCurrencyCode}");
                    writer.WriteLine($"TextBox1 Value: {textBox1Value}");
                    writer.WriteLine($"TextBox2 Value: {textBox2Value}");
                    writer.WriteLine("-----------");
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"A apărut o eroare la salvarea informațiilor: {ex.Message}");
            }
        }

        private void SaveToPersoaneFile(string suma, string valuta, string sumaConvertita)
        {
            try
            {
                string linie = $"Utilizatorul a schimbat {suma} {valuta} și a obținut suma de {sumaConvertita}{exchangeCurrencyCode}.";

                using (StreamWriter writer = new StreamWriter(PersoaneFilePath, true))
                {
                    writer.WriteLine(linie);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"A apărut o eroare la salvarea datelor: {ex.Message}");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True;Connect Timeout=30");
        //C:\\Users\\Sabin\\Documents

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void populareTabel()
        {
            try
            {
                string query = "SELECT * FROM Angajati";
                SqlDataAdapter sda = new SqlDataAdapter(query, conn);
                SqlCommandBuilder scb = new SqlCommandBuilder(sda);
                var ds = new DataSet();
                sda.Fill(ds);
                dgvAngajati.AutoGenerateColumns = true;
                dgvAngajati.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nu s-a reușit popularea tabelului!\n" + ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                populareTabel();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }


        private void dgvAngajati_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Doriți să închideți aplicația?", "Închidere aplicație", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
