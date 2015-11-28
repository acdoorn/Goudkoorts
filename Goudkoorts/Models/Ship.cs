using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Goudkoorts
{
    public class Ship
    {
        public int Inventory = 0;
        public int Room = 8;


        public Boolean isFull()
        {
            if(Inventory >= Room)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
