        // *************************************
        private void Form1_Load(object sender, EventArgs z)
        {
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            aTimer.Interval = 20000;
            aTimer.Enabled = true;
            CheckMail();
        }
        
        // *************************************
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            CheckMail();
        }
        // *************************************
        void updatePic()
        {
            if (InvokeRequired)
            { Invoke(new MethodInvoker(switchPic)); }
            else
            { switchPic(); }
        }
        
        // *************************************
        void switchPic()
        {
            picEmail.Visible = !picEmail.Visible;
        }
        // *************************************
        void CheckMail() {
            updatePic(); // visible=true
            {            
                // procedure to check mail and update Grid list (with another Invoke)
            }
            
            updatePic(); // visible=false
        }
