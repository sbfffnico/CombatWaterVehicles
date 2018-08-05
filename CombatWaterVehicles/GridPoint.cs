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
        private bool[,] _hit = new bool[10,10];
        private string[,] _buttonText = new string[10,10];
        private char[,] _hiddenShip = new char[10,10];

        public bool[,] Hit
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

        public string[,] ButtonText
        {
            get
            {
                return _buttonText;
            }
            set
            {
                _buttonText = value;
            }
        }

        public char[,] HiddenShip
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
                    Hit[i,j] = false;
                    ButtonText[i,j] = "";
                    HiddenShip[i,j] = 'O';
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
                    Hit[i,j] = false;
                    ButtonText[i,j] = "";
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

            Random random = new Random();

            foreach(var ship in ships)
            {
                bool shipsNeeded = true;

                while (shipsNeeded)
                {
                    var column = random.Next(0, 10);
                    var row = random.Next(0, 10);

                    var orientation = random.Next(1, 101) % 2; // 0 will be vertical, 1 will be horizontal

                    if (orientation == 1)
                    {
                        column = random.Next(0, 10 - ship.Width);
                        for (int i = 0; i < ship.Width; i++)
                        {
                            if (HiddenShip[row, column] == 'O')
                            {
                                enemyGrid[row][column].Text = "P"; // visually represents randomized enemy grid
                                HiddenShip[row, column] = 'P';
                                column++;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    else
                    {
                        row = random.Next(0, 10 - ship.Width);
                        for (int i = 0; i < ship.Width; i++)
                        {
                            if (HiddenShip[row, column] == 'O')
                            {
                                enemyGrid[row][column].Text = "P"; // visually represents randomized enemy grid
                                HiddenShip[row, column] = 'P';
                                row++;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }

                    shipsNeeded = false;
                }
            }
            



        }
    }
}
