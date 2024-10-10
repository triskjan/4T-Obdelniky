﻿using System;
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
                tbObvod.Text = aktualniObdelnik.Obvod.ToString();
                tbObsah.Text = aktualniObdelnik.Obsah.ToString();
            }
        }

        private void načístToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //pro nacteni pouzijte StreamReader idealne v pripojenem rezimu
            using (StreamReader streamReader = new StreamReader("obdelniky.csv",encoding: Encoding.UTF8))
            {
                streamReader.ReadLine();
                while (!streamReader.EndOfStream)
                    listBox1.Items.Add(new Obdelnik(streamReader.ReadLine()));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (JeVybranaPolozkaVSeznamu)
            {
                aktualniObdelnik.StranaA = Convert.ToInt32(tbStranaA.Text);
                aktualniObdelnik.StranaB = Convert.ToInt32(tbStranaB.Text);
                listBox1.Items[listBox1.SelectedIndex] = listBox1.Items[listBox1.SelectedIndex];
            }
            Obdelnik o = new Obdelnik(4, 20);
            Obdelnik o2 = new Trojuhelnik(4, 5, 6);
            Trojuhelnik t = new Trojuhelnik(4, 5, 6);
            List<Obdelnik> seznam = new List<Obdelnik>();
            seznam.Add(o);
            seznam.Add(o2);
            seznam.Add(t);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Obdelnik o1 = new Obdelnik(4, 5); //18
            Trojuhelnik t1 = new Trojuhelnik(4, 5, 6);//15
            Obdelnik t2 = new Trojuhelnik(4, 5, 6); //15
            string vystup = "o1: " + o1.Obvod.ToString() + Environment.NewLine;
            vystup += "t1: " + t1.Obvod.ToString() + Environment.NewLine;
            //if(t2 is  Trojuhelnik)
            vystup+= "t2: " + t2.Obvod.ToString() + Environment.NewLine;
            MessageBox.Show(vystup);
        }
    }
}
