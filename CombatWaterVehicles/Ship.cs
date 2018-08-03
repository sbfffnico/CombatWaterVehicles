using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatWaterVehicles
{
    public abstract class Ship : Ihits, IWidth, IType, IDestroyed
    {
        /// <summary>
        /// Determines the hits the ship has taken
        /// </summary>
        public int Hits { get; set; }

        /// <summary>
        /// Determines the width, or size, of the ship
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Sets the type, or name, of the ship
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Determines whether the shit has been sunk, or is still floating
        /// </summary>
        /// <returns>Returns true if the ship as sunk, false if the ship has not.</returns>
        public bool IsDestroyed
        {
            get
            {
                return Hits == Width;
            }
        }
    }
}
