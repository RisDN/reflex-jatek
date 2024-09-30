using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace borze_reflex_jatek
{
    internal class Player
    {
        public static List<Player> players = new List<Player>();

        public string Name { get; set; }
        public List<int> Score = new List<int>();
        public List<int> Time = new List<int>();

        public int HighestScore => Score.Max();
        public int HighestTime => Time[Score.IndexOf(Score.Max())];

        public double ScorePerSec => (double) HighestScore / (HighestTime);

        public Player(string name, int score, int time)
        {

            Console.WriteLine("Score:" + score + " time:"  + time);
            this.Name = name;
            this.Score.Add(score);
            this.Time.Add(time);

            players.Add(this);
        }

        public void AddScore(int score)
        {
            Score.Add(score);
        }

        public void AddTime(int time)
        {
            Time.Add(time);
        }

        public string GetScorePerSec()
        {
            return ScorePerSec.ToString("0.00");
        }

        public static Player GetPlayerByName(string name)
        {
            return players.Find(p => p.Name == name);
        }


        public static void SavePlayers()
        {
            StreamWriter sw = new StreamWriter(@"players.txt");

            foreach (Player player in players)
            {
                sw.WriteLine(player.Name + ";" + player.HighestScore + ";" + player.HighestTime);
            }

            sw.Close();
        }

        public static void LoadPlayers()
        {
            if(!File.Exists(@"players.txt"))
            {
                return;
            }

            StreamReader sr = new StreamReader(@"players.txt");

            string line;
            while ((line = sr.ReadLine()) != null)
            { 
                string[] parts = line.Split(';');
                new Player(parts[0], int.Parse(parts[1]), int.Parse(parts[2]));
            }
            sr.Close();
        }

    }
}
