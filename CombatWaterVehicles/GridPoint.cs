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
        private bool[][] _hit;
        private string[][] _text = "";
        private char[][] _hiddenShip;

        public bool[][] Hit
        {
            get
            {
                return _hit;
            }
            set
            {
                _hit = value;
            }
        }

        public string[][] Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
            }
        }

        public char[][] HiddenShip
        {
            get
            {
                return _hiddenShip;
            }
            set
            {
                _hiddenShip = value;
            }
        }

        /// <summary>
        /// Default constructor for GridPoint creation and assignment
        /// </summary>
        public GridPoint()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Text[i][j] = "";
                    Hit[i][j] = false;
                    HiddenShip[i][j] = 'O';
                }
            }
        }

        /// <summary>
        /// Parameterized constructor to for GridPoint creation and assignment
        /// </summary>
        /// <param name="grid">Needs a List of a List of Buttons passed</param>
        public GridPoint(List<List<Button>> grid)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Text[i][j] = "";
                    Hit[i][j] = false;
                }
            }
        }

        /// <summary>
        /// Method used to randomize ship placement for enemy grid
        /// </summary>
        /// <param name="enemyGrid">Parameter of a list of a list of buttons for enemy side of grid</param>
        public void SetEnemyShips(List<List<Button>> enemyGrid)
        {
            List<Ship> ships = new List<Ship>();

            ships.Add(new Destroyer());
            ships.Add(new Submarine());
            ships.Add(new Cruiser());
            ships.Add(new Battleship());
            ships.Add(new Carrier());

            foreach(var ship in ships)
            {
                MessageBox.Show("Type " + ship.Type + "'s width is " + ship.Width + " and currently has " + ship.Hits + " hits");
            }


        }
    }
}
