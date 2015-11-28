using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    public class Track
    {
        Direction direction;
        public Cart Cart;
        public Track Next;
        public int Index;
        public String Type { get; set; }
        public String Display;

        public Track()
        {
            Type = "Track";
            Display = "-";
        }

        public Track(int index, String displaytext)
        {
            Type = "Track";
            Index = index;

            if (displaytext == null)
            {
                displaytext = "-";
            }
            Display = displaytext;
        }
    }
}
