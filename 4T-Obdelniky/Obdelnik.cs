using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4T_Obdelniky
{
    internal class Obdelnik
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
        public Obdelnik(string stranaA, string stranaB)
        {
            StranaA = Convert.ToInt32(stranaA);
            StranaB = Convert.ToInt32(stranaB);
        }
        public string ToCSV() => StranaA + ";" + StranaB;

        public override string ToString() => "Obdelník " + " strana A: " + StranaA + ", strana B: " + StranaB;
        //$"Obdélník strana A: {stranaA}, stranaB: {stranaB}";
    }
}
