        private void buttonTwo_Click(object sender, EventArgs e)
        {
            sayingTwo.Visible = true;
            buttonTwo.Text = "Click To Hide Saying";
            buttonTwo.Click += new EventHandler(buttonTwo_Click2);
        }
        System.Windows.Forms.Timer tm2 = new System.Windows.Forms.Timer();
        private void buttonTwo_Click2(object sender, EventArgs e)
        {
           DoClickWork();
        }
        private void DoClickWork()
        {
            if(sayingTwo.Visible == true)
            {
                buttonTwo .Enabled = false;
                sayingTwo.Visible = false;
                buttonTwo.Text = "Reactivating in 5 seconds";
                tm2.Interval = (1000);
                tm2.Tick += new EventHandler(timer2_Tick);
                tm2.Enabled = true;
            }
        }
        int ii = 4;
        private void timer2_Tick(object sender, EventArgs e)
        {
           while (ii != 0)
           {
               buttonTwo.Text = "Reactivating in " + ii + " seconds";
               ii -= 1;
           }
           if (ii == 0)
           {
               ii += 4;
               tm2.Enabled = false;
               buttonTwo.Enabled = true;
               DoClickWork();
                
            }
        }
