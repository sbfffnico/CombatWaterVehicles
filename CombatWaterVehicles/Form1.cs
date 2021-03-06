﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CombatWaterVehicles
{
    public partial class Form1 : Form
    {
        private bool _whoseTurn = true; // true when its players turn
        private bool _disableSetShipEventHandler = false;
        private int _destroyerSet = 0;
        private int _submarineSet = 0;
        private int _cruiserSet = 0;
        private int _battleshipSet = 0;
        private int _carrierSet = 0;

        public bool WhoseTurn
        {
            get
            {
                return _whoseTurn;
            }

            set
            {
                _whoseTurn = value;
            }
        }

        public bool DisableSetShipEventHandler
        {
            get
            {
                return _disableSetShipEventHandler;
            }
            set
            {
                value = _disableSetShipEventHandler;
            }
        }

        public int DestroyerSet
        {
            get
            {
                return _destroyerSet;
            }
            set
            {
                if (_destroyerSet < 2)
                {
                    _destroyerSet = value;
                }
            }
        }

        public int SubmarineSet
        {
            get
            {
                return _submarineSet;
            }
            set
            {
                if (_submarineSet < 3)
                {
                    _submarineSet = value;
                }
            }
        }

        public int CruiserSet
        {
            get
            {
                return _cruiserSet;
            }
            set
            {
                if (_cruiserSet < 3)
                {
                    _cruiserSet = value;
                }
            }
        }

        public int BattleshipSet
        {
            get
            {
                return _battleshipSet;
            }
            set
            {
                if (_battleshipSet < 4)
                {
                    _battleshipSet = value;
                }
            }
        }

        public int CarrierSet
        {
            get
            {
                return _carrierSet;
            }
            set
            {
                if (_carrierSet < 5)
                {
                    _carrierSet = value;
                }              
            }
        }



        public Form1()
        {
            InitializeComponent();
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult exitGame = new DialogResult();
            exitGame = MessageBox.Show("Are you sure you want to exit the game?", "Choose Wisely!", MessageBoxButtons.YesNo);

            if (exitGame == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Based upon the plastic board game created by Milton Bradley in 1967\n Application developed by Nico Edrich\n Final Project CSC260", "About");
        }

        private void StartGame_Click(object sender, EventArgs e)
        {
            // will disable button after start game has been pressed
            Button b = (Button)sender;
            b.Enabled = false;

            DisableSetShipEventHandler = false;

            List<List<Button>> myGridHolder = SetButtonsMyGrid();
            List<List<Button>> enemyGridHolder = SetButtonsEnemyGrid();

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    myGridHolder[i][j].Text = "O";
                    myGridHolder[i][j].Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                    enemyGridHolder[i][j].Text = "O";
                    enemyGridHolder[i][j].Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }

            GridPoint enemyGrid = new GridPoint();
            GridPoint myGrid = new GridPoint(myGridHolder);
            

            enemyGrid.SetEnemyShips(enemyGridHolder);

            MessageBox.Show("Select two spots to place your Destroyer");
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("O indicates an Open spot\n\nX indicates a hit ship\n\nSet of X's in red indicate a sunken ship", "Help");
        }

        private void SetShips(object sender, EventArgs e)
        {
            List<List<Button>> myGrid = SetButtonsMyGrid();

            Destroyer myDestroyer = new Destroyer();
            Submarine mySubmarine = new Submarine();
            Cruiser myCruiser = new Cruiser();
            Battleship myBattleship = new Battleship();
            Carrier myCarrier = new Carrier();

            // will disable handler after ships are all placed
            if (DisableSetShipEventHandler)
            {
                return;
            }

            Button b = (Button)sender;

            if (DestroyerSet < myDestroyer.Width && b.Text == "O")
            {
                DestroyerSet += 1;
                b.Text = "D";
                if (DestroyerSet < myDestroyer.Width)
                {
                    MessageBox.Show("Select another spot to place Destroyer");
                }
                else
                {
                    MessageBox.Show("Select three spots to place Submarine");
                }
            }
            else if (SubmarineSet < mySubmarine.Width && b.Text == "O")
            {
                SubmarineSet += 1;
                b.Text = "S";
                if (SubmarineSet < mySubmarine.Width)
                {
                    MessageBox.Show("Select another spot to place Submarine");
                }
                else
                {
                    MessageBox.Show("Select three spots to place Cruiser");
                }
                
            }
            else if (CruiserSet < myCruiser.Width && b.Text == "O")
            {
                CruiserSet += 1;
                b.Text = "Cr";
                if (CruiserSet < myCruiser.Width)
                {
                    MessageBox.Show("Select another spot to place Cruiser");
                }
                else
                {
                    MessageBox.Show("Select four spots to place Battleship");
                }
                
            }
            else if (BattleshipSet < myBattleship.Width && b.Text == "O")
            {
                
                b.Text = "B";
                BattleshipSet += 1;
                if (BattleshipSet < myBattleship.Width)
                {
                    MessageBox.Show("Select another spot to place Battleship");
                }
                else
                {
                    MessageBox.Show("Select five spots to place Carrier");
                }
            }
            else if (CarrierSet < myCarrier.Width && b.Text == "O")
            {
                
                b.Text = "Ca";
                CarrierSet += 1;
                if (CarrierSet < myCarrier.Width)
                {
                    MessageBox.Show("Select another spot to place Carrier");
                }
                else
                {
                    MessageBox.Show("All ships have been placed.");
                }
            }
            else
            {
                DisableSetShipEventHandler = true;
            }
        }

        public List<List<Button>> SetButtonsMyGrid()
        {
            List<List<Button>> myGrid = new List<List<Button>>();

            myGrid.Add(new List<Button>());
            myGrid[0].Add(MyBoard_A1);
            myGrid[0].Add(MyBoard_B1);
            myGrid[0].Add(MyBoard_C1);
            myGrid[0].Add(MyBoard_D1);
            myGrid[0].Add(MyBoard_E1);
            myGrid[0].Add(MyBoard_F1);
            myGrid[0].Add(MyBoard_G1);
            myGrid[0].Add(MyBoard_H1);
            myGrid[0].Add(MyBoard_I1);
            myGrid[0].Add(MyBoard_J1);

            myGrid.Add(new List<Button>());
            myGrid[1].Add(MyBoard_A2);
            myGrid[1].Add(MyBoard_B2);
            myGrid[1].Add(MyBoard_C2);
            myGrid[1].Add(MyBoard_D2);
            myGrid[1].Add(MyBoard_E2);
            myGrid[1].Add(MyBoard_F2);
            myGrid[1].Add(MyBoard_G2);
            myGrid[1].Add(MyBoard_H2);
            myGrid[1].Add(MyBoard_I2);
            myGrid[1].Add(MyBoard_J2);

            myGrid.Add(new List<Button>());
            myGrid[2].Add(MyBoard_A3);
            myGrid[2].Add(MyBoard_B3);
            myGrid[2].Add(MyBoard_C3);
            myGrid[2].Add(MyBoard_D3);
            myGrid[2].Add(MyBoard_E3);
            myGrid[2].Add(MyBoard_F3);
            myGrid[2].Add(MyBoard_G3);
            myGrid[2].Add(MyBoard_H3);
            myGrid[2].Add(MyBoard_I3);
            myGrid[2].Add(MyBoard_J3);

            myGrid.Add(new List<Button>());
            myGrid[3].Add(MyBoard_A4);
            myGrid[3].Add(MyBoard_B4);
            myGrid[3].Add(MyBoard_C4);
            myGrid[3].Add(MyBoard_D4);
            myGrid[3].Add(MyBoard_E4);
            myGrid[3].Add(MyBoard_F4);
            myGrid[3].Add(MyBoard_G4);
            myGrid[3].Add(MyBoard_H4);
            myGrid[3].Add(MyBoard_I4);
            myGrid[3].Add(MyBoard_J4);

            myGrid.Add(new List<Button>());
            myGrid[4].Add(MyBoard_A5);
            myGrid[4].Add(MyBoard_B5);
            myGrid[4].Add(MyBoard_C5);
            myGrid[4].Add(MyBoard_D5);
            myGrid[4].Add(MyBoard_E5);
            myGrid[4].Add(MyBoard_F5);
            myGrid[4].Add(MyBoard_G5);
            myGrid[4].Add(MyBoard_H5);
            myGrid[4].Add(MyBoard_I5);
            myGrid[4].Add(MyBoard_J5);

            myGrid.Add(new List<Button>());
            myGrid[5].Add(MyBoard_A6);
            myGrid[5].Add(MyBoard_B6);
            myGrid[5].Add(MyBoard_C6);
            myGrid[5].Add(MyBoard_D6);
            myGrid[5].Add(MyBoard_E6);
            myGrid[5].Add(MyBoard_F6);
            myGrid[5].Add(MyBoard_G6);
            myGrid[5].Add(MyBoard_H6);
            myGrid[5].Add(MyBoard_I6);
            myGrid[5].Add(MyBoard_J6);

            myGrid.Add(new List<Button>());
            myGrid[6].Add(MyBoard_A7);
            myGrid[6].Add(MyBoard_B7);
            myGrid[6].Add(MyBoard_C7);
            myGrid[6].Add(MyBoard_D7);
            myGrid[6].Add(MyBoard_E7);
            myGrid[6].Add(MyBoard_F7);
            myGrid[6].Add(MyBoard_G7);
            myGrid[6].Add(MyBoard_H7);
            myGrid[6].Add(MyBoard_I7);
            myGrid[6].Add(MyBoard_J7);

            myGrid.Add(new List<Button>());
            myGrid[7].Add(MyBoard_A8);
            myGrid[7].Add(MyBoard_B8);
            myGrid[7].Add(MyBoard_C8);
            myGrid[7].Add(MyBoard_D8);
            myGrid[7].Add(MyBoard_E8);
            myGrid[7].Add(MyBoard_F8);
            myGrid[7].Add(MyBoard_G8);
            myGrid[7].Add(MyBoard_H8);
            myGrid[7].Add(MyBoard_I8);
            myGrid[7].Add(MyBoard_J8);

            myGrid.Add(new List<Button>());
            myGrid[8].Add(MyBoard_A9);
            myGrid[8].Add(MyBoard_B9);
            myGrid[8].Add(MyBoard_C9);
            myGrid[8].Add(MyBoard_D9);
            myGrid[8].Add(MyBoard_E9);
            myGrid[8].Add(MyBoard_F9);
            myGrid[8].Add(MyBoard_G9);
            myGrid[8].Add(MyBoard_H9);
            myGrid[8].Add(MyBoard_I9);
            myGrid[8].Add(MyBoard_J9);

            myGrid.Add(new List<Button>());
            myGrid[9].Add(MyBoard_A10);
            myGrid[9].Add(MyBoard_B10);
            myGrid[9].Add(MyBoard_C10);
            myGrid[9].Add(MyBoard_D10);
            myGrid[9].Add(MyBoard_E10);
            myGrid[9].Add(MyBoard_F10);
            myGrid[9].Add(MyBoard_G10);
            myGrid[9].Add(MyBoard_H10);
            myGrid[9].Add(MyBoard_I10);
            myGrid[9].Add(MyBoard_J10);

            return myGrid;
        }

        public List<List<Button>> SetButtonsEnemyGrid()
        {
            List<List<Button>> enemyGrid = new List<List<Button>>();

            enemyGrid.Add(new List<Button>());
            enemyGrid[0].Add(EnemyBoard_A1);
            enemyGrid[0].Add(EnemyBoard_B1);
            enemyGrid[0].Add(EnemyBoard_C1);
            enemyGrid[0].Add(EnemyBoard_D1);
            enemyGrid[0].Add(EnemyBoard_E1);
            enemyGrid[0].Add(EnemyBoard_F1);
            enemyGrid[0].Add(EnemyBoard_G1);
            enemyGrid[0].Add(EnemyBoard_H1);
            enemyGrid[0].Add(EnemyBoard_I1);
            enemyGrid[0].Add(EnemyBoard_J1);

            enemyGrid.Add(new List<Button>());
            enemyGrid[1].Add(EnemyBoard_A2);
            enemyGrid[1].Add(EnemyBoard_B2);
            enemyGrid[1].Add(EnemyBoard_C2);
            enemyGrid[1].Add(EnemyBoard_D2);
            enemyGrid[1].Add(EnemyBoard_E2);
            enemyGrid[1].Add(EnemyBoard_F2);
            enemyGrid[1].Add(EnemyBoard_G2);
            enemyGrid[1].Add(EnemyBoard_H2);
            enemyGrid[1].Add(EnemyBoard_I2);
            enemyGrid[1].Add(EnemyBoard_J2);

            enemyGrid.Add(new List<Button>());
            enemyGrid[2].Add(EnemyBoard_A3);
            enemyGrid[2].Add(EnemyBoard_B3);
            enemyGrid[2].Add(EnemyBoard_C3);
            enemyGrid[2].Add(EnemyBoard_D3);
            enemyGrid[2].Add(EnemyBoard_E3);
            enemyGrid[2].Add(EnemyBoard_F3);
            enemyGrid[2].Add(EnemyBoard_G3);
            enemyGrid[2].Add(EnemyBoard_H3);
            enemyGrid[2].Add(EnemyBoard_I3);
            enemyGrid[2].Add(EnemyBoard_J3);

            enemyGrid.Add(new List<Button>());
            enemyGrid[3].Add(EnemyBoard_A4);
            enemyGrid[3].Add(EnemyBoard_B4);
            enemyGrid[3].Add(EnemyBoard_C4);
            enemyGrid[3].Add(EnemyBoard_D4);
            enemyGrid[3].Add(EnemyBoard_E4);
            enemyGrid[3].Add(EnemyBoard_F4);
            enemyGrid[3].Add(EnemyBoard_G4);
            enemyGrid[3].Add(EnemyBoard_H4);
            enemyGrid[3].Add(EnemyBoard_I4);
            enemyGrid[3].Add(EnemyBoard_J4);

            enemyGrid.Add(new List<Button>());
            enemyGrid[4].Add(EnemyBoard_A5);
            enemyGrid[4].Add(EnemyBoard_B5);
            enemyGrid[4].Add(EnemyBoard_C5);
            enemyGrid[4].Add(EnemyBoard_D5);
            enemyGrid[4].Add(EnemyBoard_E5);
            enemyGrid[4].Add(EnemyBoard_F5);
            enemyGrid[4].Add(EnemyBoard_G5);
            enemyGrid[4].Add(EnemyBoard_H5);
            enemyGrid[4].Add(EnemyBoard_I5);
            enemyGrid[4].Add(EnemyBoard_J5);

            enemyGrid.Add(new List<Button>());
            enemyGrid[5].Add(EnemyBoard_A6);
            enemyGrid[5].Add(EnemyBoard_B6);
            enemyGrid[5].Add(EnemyBoard_C6);
            enemyGrid[5].Add(EnemyBoard_D6);
            enemyGrid[5].Add(EnemyBoard_E6);
            enemyGrid[5].Add(EnemyBoard_F6);
            enemyGrid[5].Add(EnemyBoard_G6);
            enemyGrid[5].Add(EnemyBoard_H6);
            enemyGrid[5].Add(EnemyBoard_I6);
            enemyGrid[5].Add(EnemyBoard_J6);

            enemyGrid.Add(new List<Button>());
            enemyGrid[6].Add(EnemyBoard_A7);
            enemyGrid[6].Add(EnemyBoard_B7);
            enemyGrid[6].Add(EnemyBoard_C7);
            enemyGrid[6].Add(EnemyBoard_D7);
            enemyGrid[6].Add(EnemyBoard_E7);
            enemyGrid[6].Add(EnemyBoard_F7);
            enemyGrid[6].Add(EnemyBoard_G7);
            enemyGrid[6].Add(EnemyBoard_H7);
            enemyGrid[6].Add(EnemyBoard_I7);
            enemyGrid[6].Add(EnemyBoard_J7);

            enemyGrid.Add(new List<Button>());
            enemyGrid[7].Add(EnemyBoard_A8);
            enemyGrid[7].Add(EnemyBoard_B8);
            enemyGrid[7].Add(EnemyBoard_C8);
            enemyGrid[7].Add(EnemyBoard_D8);
            enemyGrid[7].Add(EnemyBoard_E8);
            enemyGrid[7].Add(EnemyBoard_F8);
            enemyGrid[7].Add(EnemyBoard_G8);
            enemyGrid[7].Add(EnemyBoard_H8);
            enemyGrid[7].Add(EnemyBoard_I8);
            enemyGrid[7].Add(EnemyBoard_J8);

            enemyGrid.Add(new List<Button>());
            enemyGrid[8].Add(EnemyBoard_A9);
            enemyGrid[8].Add(EnemyBoard_B9);
            enemyGrid[8].Add(EnemyBoard_C9);
            enemyGrid[8].Add(EnemyBoard_D9);
            enemyGrid[8].Add(EnemyBoard_E9);
            enemyGrid[8].Add(EnemyBoard_F9);
            enemyGrid[8].Add(EnemyBoard_G9);
            enemyGrid[8].Add(EnemyBoard_H9);
            enemyGrid[8].Add(EnemyBoard_I9);
            enemyGrid[8].Add(EnemyBoard_J9);

            enemyGrid.Add(new List<Button>());
            enemyGrid[9].Add(EnemyBoard_A10);
            enemyGrid[9].Add(EnemyBoard_B10);
            enemyGrid[9].Add(EnemyBoard_C10);
            enemyGrid[9].Add(EnemyBoard_D10);
            enemyGrid[9].Add(EnemyBoard_E10);
            enemyGrid[9].Add(EnemyBoard_F10);
            enemyGrid[9].Add(EnemyBoard_G10);
            enemyGrid[9].Add(EnemyBoard_H10);
            enemyGrid[9].Add(EnemyBoard_I10);
            enemyGrid[9].Add(EnemyBoard_J10);

            return enemyGrid;
        }

        
    }
}