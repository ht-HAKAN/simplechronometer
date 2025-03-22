using System;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace MyChronometer
{
    public partial class chronometer : Form
    {
        private Timer timer;
        private int milliseconds, seconds, minutes, hours;

        public chronometer()
        {
            InitializeComponent();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            timer = new Timer
            {
                Interval = 10
            };
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            milliseconds += 10;

            if (milliseconds >= 1000)
            {
                milliseconds = 0;
                seconds++;
            }
            if (seconds >= 60)
            {
                seconds = 0;
                minutes++;
            }
            if (minutes >= 60)
            {
                minutes = 0;
                hours++;
            }


            UpdateLabel();
        }

        private void UpdateLabel()
        {
            label1.Text = $"{hours:00}:{minutes:00}:{seconds:00}:{milliseconds / 10:00}";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer.Stop();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            timer.Stop();
            milliseconds = seconds = minutes = hours = 0;
            UpdateLabel();
        }
    }
}