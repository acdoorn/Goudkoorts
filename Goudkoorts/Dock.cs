using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    class Dock : Track
    {
        public Ship Ship;
        public bool hasShip()
        {
            if (!Ship.Equals(null))
            {
                return true;
            }
            return false;
        }

        public int RoundsWithoutShip { get; set; }

        internal int fillShip()
        {
            throw new NotImplementedException();
        }
    }
}
