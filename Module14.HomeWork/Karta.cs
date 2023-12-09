using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module14.HomeWork
{
    public class Karta
    {
        public string Mast { get; }
        public string Tip { get; }
        public Karta(string mast, string tip)
        {
            Mast = mast;
            Tip = tip;
        }
        public int CompareTo(Karta other)
        {
            return String.Compare(Tip, other.Tip, StringComparison.Ordinal);
        }
    }
}
