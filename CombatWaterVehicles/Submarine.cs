using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatWaterVehicles
{
    public class Submarine : Ship
    {
        /// <summary>
        /// Declares the default constructor for Submarine type ship
        /// </summary>
        public Submarine()
        {
            Type = "Submarine";
            Width = 3;
            Hits = 0;
        }
    }
}
