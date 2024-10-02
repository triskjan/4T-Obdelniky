using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4T_Obdelniky
{
    public class Obdelnik
    {
        public int StranaA { get; set; } = 0;
        public int StranaB { get; set; } = 0;
        public int Obsah { get => StranaA * StranaB; }
        public int Obvod { get { return 2 * (StranaA + StranaB); } }


        public Obdelnik(int stranaA, int stranaB)
        {
            StranaA = stranaA;
            StranaB = stranaB;
        }
        public Obdelnik(string CSVLine)
        {
            StranaA = Convert.ToInt32(CSVLine.Split(';')[0]);
            StranaB = Convert.ToInt32(CSVLine.Split(';')[1]);
        }
        public Obdelnik(string stranaA, string stranaB)
        {
            StranaA = Convert.ToInt32(stranaA);
            StranaB = Convert.ToInt32(stranaB);
        }
        public virtual string ToCSV() => StranaA + ";" + StranaB;

        public override string ToString() => "Obdelník " + " strana A: " + StranaA + ", strana B: " + StranaB;
        //$"Obdélník strana A: {stranaA}, stranaB: {stranaB}";
    }
    public class Trojuhelnik : Obdelnik
    {
        public int StranaC { get; set; } = 0;
        public Trojuhelnik(int stranaA, int stranaB, int stranaC) : base(stranaA, stranaB)
        {
            this.StranaC = stranaC;
        }

        public Trojuhelnik(string CSVLine) : base(CSVLine)
        {

        }

        public int Obvod => base.Obvod/2+StranaC;

        public override string ToCSV()
        {
            return base.ToCSV() + ";" + this.StranaC;
        }
    }
}
