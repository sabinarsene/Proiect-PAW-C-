using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace proiect_paw
{
    public partial class fisier : Form
    {
        public fisier()
        {
            InitializeComponent();
        }

        private void textBoxf_TextChanged(object sender, EventArgs e)
        {

        }
        public void AfiseazaDate(string[] linii)
        {
            foreach (string linie in linii)
            {
                textBoxf.AppendText(linie + Environment.NewLine);
            }
        }

        private void fisier_Load(object sender, EventArgs e)
        {

        }

        private void serializareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("fisier.dat",
                FileMode.Create, FileAccess.Write);
            //bf.Serialize(fs, textBox1.Text);
            bf.Serialize(fs, textBoxf.Text);
            fs.Close();
            textBoxf.Clear();
        }

        private void dToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("fisier.dat",
                FileMode.Open, FileAccess.Read);
            textBoxf.Text = (string)bf.Deserialize(fs);
            fs.Close();
        }

        private void schimbaCuloareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
                //this.BackColor = dlg.Color;
                contextMenuStrip1.SourceControl.BackColor = dlg.Color;
        }
    }
}
