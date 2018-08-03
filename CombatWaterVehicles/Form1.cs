using System;
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
        
    }
}