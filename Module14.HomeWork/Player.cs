using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module14.HomeWork
{
    public class Player
    {
        public List<Karta> Koloda { get; } = new List<Karta>();
        public int Number { get; }
        public void PrintKoloda()
        {
            foreach (var karta in Koloda)
            {
                Console.WriteLine($"{karta.Mast} {karta.Tip}");
            }
        }
        public Player(int number)
        {
            Number = number;
        }
        public override string ToString()
        {
            return $"Игрок {Number}";
        }
    }
}
