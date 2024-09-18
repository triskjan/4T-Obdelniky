using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4T_Obdelniky
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private bool JeVybranaPolozkaVSeznamu => listBox1.SelectedIndex != -1;
        Obdelnik aktualniObdelnik;
        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(new Obdelnik(tbStranaA.Text, tbStranaB.Text));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (JeVybranaPolozkaVSeznamu)
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
        }

        private void uložitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (StreamWriter streamWriter = new StreamWriter("obdelniky.csv", false, Encoding.UTF8))
            {
                //CSV
                //hlavicka - stranaA,stranaB
                streamWriter.WriteLine("stranaA;stranaB");
                foreach (Obdelnik obdelnik in listBox1.Items)
                {
                    //streamWriter.WriteLine(obdelnik.StranaA + ";" + obdelnik.StranaB);
                    streamWriter.WriteLine(obdelnik.ToCSV());
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (JeVybranaPolozkaVSeznamu)
            {
                aktualniObdelnik = listBox1.SelectedItem as Obdelnik;
                tbStranaA.Text = aktualniObdelnik.StranaA.ToString();
                //tbStranaB.Text = (listBox1.Items[listBox1.SelectedIndex] as Obdelnik).StranaB.ToString();
                tbStranaB.Text = aktualniObdelnik.StranaB.ToString();
                //pri vyberu polozky zobrazte i detail o obvodu a obsahu
            }
        }

        private void načístToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //pro nacteni pouzijte StreamReader idealne v pripojenem rezimu
        }
    }
}
