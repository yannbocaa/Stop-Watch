using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StopWatch
{
    public partial class StopWatch : Form
    {
        private DateTime startTime;
        private bool isRunning = false;

        public StopWatch()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // Set a value to start time
            // startTime = DateTime.Now;

            //Start the timer
            //formTimer.Start();

            if (!isRunning)
            {
                startTime = DateTime.Now;
                formTimer.Start();
                isRunning = true;
            }
            else 
            {
                startTime += DateTime.Now - startTime;
                formTimer.Start();
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            formTimer.Stop();
            isRunning = false;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            formTimer.Stop();
            watchLabel.Text = "00:00.00";
            isRunning = false;
        }

        private void formTimer_Tick(object sender, EventArgs e)
        {
            // Calculate how long it's been since start
            TimeSpan span = DateTime.Now - startTime;
            watchLabel.Text = span.ToString(@"mm\:ss\.ff");  
        }
    }
}
