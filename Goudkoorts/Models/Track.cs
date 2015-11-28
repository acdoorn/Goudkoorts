using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    public class Track
    {
        public Cart Cart;
        public Track Next;
        public int Index;
        public String Type { get; set; }
        public String display = "-";

        public Track()
        {
            Type = "Track";
        }

        public Track(int index, String displaytext)
        {
            Type = "Track";
            Index = index;

            if (displaytext == null)
            {
                displaytext = "-";
            }
            display = displaytext;
        }

        public String Display
        {

            get
            {
                if (Cart != null)
                {
                    return "X";
                }
                return display;

            }
            set { display = value; }
        }

    }
}
