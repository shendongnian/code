    public class Update
    {
        private Timer timer1;
        
        public void Update()
        {            
            public void InitTimer()
            {
                timer1 = new Timer();
                timer1.Tick += new EventHandler(timer1_Tick);
                timer1.Interval = 2000; // in miliseconds
                timer1.Start();
            }
            private void timer1_Tick(object sender, EventArgs e)
            {
                CheckForUpate();
            }
            
            private void CheckForUpdate()
            {
                //Here you connect to your table and do:
                //SELECT UPDATESTRING FROM UPDATE WHERE USERID = THISUSER
                //if(dr.Read()) - if he read something - we will say it got label5|changedText
                string updateStringWeImitate = "label5|changedText"; //this you will get from SELECT
                
                string[] ss = updateStringWeImitate.Split('|');
                switch(ss[0])
                {
                    case "label5":
                    label5.Text = ss[1];
                    break;
                }
            }
        }
    }
