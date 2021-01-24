    namespace timerprogram
    {
        public partial class doeverysecond : Form
        {
            //Timer is class level, so it sticks around and can be called from
            //multiple methods
            System.Timers.Timer mytimer = new System.Timers.Timer();
            int thetimeinsecs = 0; 
            private void Form1_Load(object sender, EventArgs e)
            {
                //Setup the timer, but don't start it
                mytimer.Elapsed += new ElapsedEventHandler(customfn);
                mytimer.Interval = 1000;
            }    
            private void customfn(object source, ElapsedEventArgs e)
            {
                //We can check the timer itself to see if it's running!
                if (mytimer.Enabled)
                {
                    thetimeinsecs = thetimeinsecs + 1;
                    MessageBox.Show(thetimeinsecs.ToString());
                }
            }
            private void button1_Click(object sender, EventArgs e)
            {
                //Start the timer!
                mytimer.Start();
            }
        }
    }
