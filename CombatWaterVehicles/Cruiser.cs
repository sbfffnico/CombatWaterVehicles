using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatWaterVehicles
{
    public class Cruiser : Ship
    {
        /// <summary>
        /// Declares the default constructor for the Cruiser type ship
        /// </summary>
        public Cruiser()
        {
            Type = "Cruiser";
            Width = 3;
            Hits = 0;
        }
    }
}
