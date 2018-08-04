using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CombatWaterVehicles
{
    public class GridPoint
    {
        /// <summary>
        /// Parameterized constructor to set GridPoints to Open 'O' slots
        /// </summary>
        /// <param name="grid">Needs a List of a List of Buttons</param>
        public GridPoint(List<List<Button>> grid)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    grid[i][j].Text = "O";
                    grid[i][j].Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }
    }
}
