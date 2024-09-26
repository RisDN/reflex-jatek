using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;

using System.Windows.Forms;

namespace borze_reflex_jatek
{
    public partial class Leaderboard : Form
    {
        public Leaderboard()
        {

            InitializeComponent();

            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.ScrollBars = ScrollBars.Vertical;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        public void UpdateLeaderboard()
        {
            dataGridView1.Rows.Clear();
            int i = 0;
            foreach (Player player in Player.players.OrderBy(p => p.HighestScore).Reverse())
            {
                i++;
                dataGridView1.Rows.Add($"# {i}", player.Name, $"{player.HighestScore}    ({player.GetScorePerSec()}/mp)");
            }

            dataGridView1.Refresh();
        }

    }
}
