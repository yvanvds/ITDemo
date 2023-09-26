using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefening.Models
{
    internal class Game
    {
        public string Name { get; set; }
        public int ReleaseYear { get; set; }
        public int Rating { get; set; }

        public Game(string name, int releaseYear, int rating)
        {
            Name = name;
            ReleaseYear = releaseYear;
            Rating = rating;
        }

        public void DisplayContents()
        {
            Console.WriteLine("---");
            Console.WriteLine(Name);
            Console.WriteLine("Released in " + ReleaseYear);
            Console.WriteLine("Rating: " + Rating);
            Console.WriteLine("---");
        }
    }
}
