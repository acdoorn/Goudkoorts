using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    class TrackSwitch : Track
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
            throw new NotImplementedException();
        }
    }
}
