using System;
using System.Windows.Forms;

namespace borze_reflex_jatek
{
    internal static class Program
    {
        public static GamerOver gameOverForm;
        public static Leaderboard leaderboard;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            gameOverForm = new GamerOver();
            leaderboard = new Leaderboard();
            leaderboard.Show();
            Player.LoadPlayers();
            leaderboard.UpdateLeaderboard();

            Application.Run(new Form1());

        }

        


    }
}
