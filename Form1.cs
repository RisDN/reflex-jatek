using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace borze_reflex_jatek
{
    public partial class Form1 : Form
    {

        public static Form1 instance;

        public Form1()
        {

            instance = this;
            InitializeComponent();

            updatePoints(0);
            updateTime(30);

            KeyPreview = true;
            KeyPress += Handle_KeyPress;


        }

        public void Handle_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'x' || e.KeyChar == 'X')
            {

                Button hoveredButton = GetButtonUnderMouse();
                if (hoveredButton != null)
                {
                    handleClick(hoveredButton, EventArgs.Empty); 
                }
            }
        }
        
        private void handleClick(object sender, EventArgs e)
        {
            GameHandler.clicked(sender);
        }
       
        public void updateTime(int timeLeft)
        {
            time_left_output.Text = timeLeft.ToString();
        }

        public void updatePoints(int points)
        {
            current_points_output.Text = points.ToString();
        }

        public List<Button> GetAllButtons()
        {
            return this.Controls.OfType<Button>().ToList();
        }

        private Button GetButtonUnderMouse()
        {

            Point mousePos = this.PointToClient(Cursor.Position);

            foreach (var button in GetAllButtons())
            {
                if (button.Bounds.Contains(mousePos))
                {
                    return button; 
                }
            }
            return null; 
        }

        public void updateProgressBar(int timeLeft)
        {
            progressBar1.Value = timeLeft;
        }
    }
}
