using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    class Track
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
        }

        public Track(int index, String displaytext)
        {
            Type = "Track";
            Index = index;
            Display = displaytext;
        }
    }
}
