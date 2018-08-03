using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombatWaterVehicles
{
        /// <summary>
        /// Interface used for the determiniation of how many hits can be taken
        /// </summary>
        public interface Ihits
        {
            int Hits { get; set; }
        }
        
        /// <summary>
        /// Interface used to determine the width of an object
        /// </summary>
        public interface IWidth
        {
            int Width { get; set; }
        }
        
        /// <summary>
        ///  Interface used to determine the name or type of an object
        /// </summary>
        public interface IType
        {
            string Type { get; set; }
        }

        /// <summary>
        /// Interface method used to determine whether an object has been sunk
        /// </summary>
        public interface IDestroyed
        {
            bool IsDestroyed { get; }
        }
}
