using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    public class TrackSwitch : Track
    {

        public TrackType TrackType;
        public Track Down;
        public Track Up;
        public Position Position;
        public TrackSwitch(TrackType t)
        {
            Type = "Switch";
            TrackType = t;
        }

        public TrackSwitch()
        {
            // TODO: Complete member initialization
        }


        internal void Switch()
        {
            if (this.Cart == null)
            {
                if (this.Position == Position.Up)
                {
                    this.Position = Position.Down;
                }
                else
                {
                    this.Position = Position.Up;
                }

                // Set icon 
                if (this.TrackType == TrackType.OneInTwoOut) // <
                {
                    if (this.Position == Position.Down)
                    {
                        this.Display = "\\";
                    }
                    else
                    {
                        this.Display = "/";
                    }
                }
                else
                { // >
                    if (this.Position == Position.Down)
                    {
                        this.Display = "/";
                    }
                    else
                    {
                        this.Display = "\\";
                    }
                }
            }
        }
    }
}
