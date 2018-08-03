using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatWaterVehicles
{
    public class Carrier : Ship
    {
        /// <summary>
        /// Declares the default constructor for Carrier type ship
        /// </summary>
        public Carrier()
        {
            Type = "Carrier";
            Width = 5;
            Hits = 0;

        }
    }
}
