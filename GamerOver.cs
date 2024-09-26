using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace borze_reflex_jatek
{
    public partial class GamerOver : Form
    {
        public GamerOver()
        {
            Hide();
            InitializeComponent();

        }


        public void SetDatas(int points, int time)
        {
            Text = time == 0 ? "Az idő lejárt!" : "Rossz helyre kattintottál!";
            double pointsPerSecond = (double)points / (30 - time);
            label1.Text = $"Elért pontszám: {points} ({pointsPerSecond:0.00}/mp)";
            label2.Text = "Idő: " + (30 - time) + " másodperc";

            textBox1.Text = "";
            textBox1.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            if(name.Length == 0)
            {
                MessageBox.Show("Nem adtál meg nevet!", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int points = int.Parse(label1.Text.Split(' ')[2]);
            int time = int.Parse(label2.Text.Split(' ')[1]);

            Player savedPlayer = Player.GetPlayerByName(name);

            if(savedPlayer == null)
            {
                new Player(name, points, time);
            } else
            {
                savedPlayer.AddScore(points);
                savedPlayer.AddTime(time);
            }
            
            Program.leaderboard.UpdateLeaderboard();
            Close();
            Player.SavePlayers();

        }


    }
}
