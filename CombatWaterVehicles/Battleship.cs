using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatWaterVehicles
{
    public class Battleship : Ship
    {
        /// <summary>
        /// Declares the default constructor for Battleship type ship
        /// </summary>
        public Battleship()
        {
            Type = "Battleship";
            Width = 4;
            Hits = 0;
        }
    }
}
