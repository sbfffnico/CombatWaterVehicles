using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatWaterVehicles
{
    public class Destroyer : Ship
    {
        /// <summary>
        /// Declares the default constructor for Destroyer type ship
        /// </summary>
        public Destroyer()
        {
            Type = "Destroyer";
            Width = 2;
            Hits = 0;
        }
    }
}
