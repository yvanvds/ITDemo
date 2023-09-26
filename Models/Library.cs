using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefening.Models
{
    internal class Library
    {
        public string Name { get; set; }
        public List<Game> Items { get; set; } = new List<Game>();
    }
}
