using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4T_Obdelniky
{
    public class Obdelnik
    {
        /// <summary>
        /// Velikost strany A
        /// </summary>
        public int StranaA { get; set; } = 0;
        public int StranaB { get; set; } = 0;
        public int Obsah { get => StranaA * StranaB; }
        public virtual int Obvod { get { return 2 * (StranaA + StranaB); } }

        public Obdelnik(int stranaA, int stranaB)
        {
            StranaA = stranaA;
            StranaB = stranaB;
        }
        public Obdelnik(string stranaA, string stranaB)
        {
            StranaA = Convert.ToInt32(stranaA);
            StranaB = Convert.ToInt32(stranaB);
        }
        public Obdelnik(string CSVLine)
        {
            StranaA = Convert.ToInt32(CSVLine.Split(';')[0]);
            StranaB = Convert.ToInt32(CSVLine.Split(';')[1]);
        }
        public static int SpocitejObsah (int stranaA, int stranaB)
        {
            return stranaA * stranaB;
        }
        //public static int SpocitejObsah(string stranaA, string stranaB)
        //{
        //    return Convert.ToInt32(stranaA) * Convert.ToInt32(stranaB);
        //}
        public static int SpocitejObsah(string stranaA, string stranaB)
        {
            return SpocitejObsah(Convert.ToInt32(stranaA), Convert.ToInt32(stranaB));
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

        public override int Obvod => base.Obvod/2+StranaC; //polymorf

        public override string ToCSV()
        {
            return base.ToCSV() + ";" + this.StranaC;
        }
    }
}
