using Oefening.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefening.Views
{
    internal class Viewer
    {
        public static void Show(List<Game> items)
        {
            for(int i = 0; i < items.Count; i++)
            {
                Console.WriteLine("[" + i + "] " + items[i].Name);
            }
        }

        public static void Show(Game item)
        {
            item.DisplayContents();
        }
    }
}
