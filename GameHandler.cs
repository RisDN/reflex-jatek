
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace borze_reflex_jatek
{
    internal class GameHandler
    {
        public static Random rnd = new Random();
        private static int currentPoints = 0;
        private static int timeLeft = 0;
        private static Form1 instance = Form1.instance;
        private static List<Button> buttons = instance.GetAllButtons();
        private static bool inGame = false;

        public static void clicked(object sender)
        {
            Button button = sender as Button;


            if (!inGame && button.BackColor == Color.Red)
            {
                startGame();
                incrementPoints();
                button.BackColor = Color.Black;
                generateNewRedButton();

                return;
            }


            if (inGame && button.BackColor != Color.Red)
            {
                endGame();
                return;
            }

            if(inGame && button.BackColor == Color.Red)
            {
                button.BackColor = Color.Black;
                generateNewRedButton();
                incrementPoints();
                return;
            }

        }

        public static void startGame()
        {

            currentPoints = 0;
            timeLeft = 30;
            inGame = true;
            startTimer();

        }

        public static void generateNewRedButton()
        {

            List<Button> blackButtons = buttons.FindAll(button => button.BackColor == Color.Black);

            int randomIndex = rnd.Next(0, blackButtons.Count);

            Button randomButton = blackButtons[randomIndex];

            randomButton.BackColor = Color.Red;

        }

        public static async void startTimer()
        {

            while (inGame)
            {
                timeLeft--;
                instance.updateTime(timeLeft);

                int percentage = (timeLeft * 100) / 30;

                instance.updateProgressBar(percentage);

                if (timeLeft <= 0 || !inGame)
                {
                    endGame();
                }

                await Task.Delay(1000);
            }
        }

        public static void endGame()
        {

            inGame = false;

            GamerOver gameOverForm = Program.gameOverForm;

            gameOverForm.SetDatas(currentPoints, timeLeft);
            gameOverForm.ShowDialog();

        } 

        public static void incrementPoints()
        {
            currentPoints++;
            instance.updatePoints(currentPoints);
        }   
    }
}
