        protected override void OnStart(string[] args){
            var timer = new Timer
            {
                Enabled = true,
                Interval = (10 * 60 * 1000)
            };
            timer.Elapsed += new System.Timers.ElapsedEventHandler(methodStart);
        }
        private int loopCounter = 0;
        bool sysDown = false;
        // Used to count the number of successful executions after a failure.
        int systemUpAfterFailureCount = 0;
        public void methodStart(object sender, ElapsedEventArgs e)
        {
            Ping p = new Ping();
            PingReply r;
            string s = "SYSTEM-IP-ADDRESS";
            int upCounter = 0;
            int downCounter = 0;
            
            
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    r = p.Send(s);
                    if (r.Status == IPStatus.Success)
                        upCounter++;
                    else
                        downCounter++;
                }
                if (downCounter >= 7)
                {
                    // LOG ENTRY
                    // EMAIL NOTIFICATION
                    downCounter = 0;
                    // The system has failed
                    sysDown = true;
                }
                else
                {
                    // Before changing the sysDown flag, check if the system was previously down
                    // This is the first successful execution after the failure
                    if (sysDown)
                        systemUpAfterFailureCount++;
                    // This will allow systemUpAfterFailureCount to increase if it is Ex: 1 and sysDown = false (Your success execution limit is 2, which we control at the IF block below)
                    if (systemUpAfterFailureCount > 1)
                        systemUpAfterFailureCount++;
                    sysDown = false;
                }
            }
            catch (Exception ex)
            {
                //EXCEPTION HANDLING
            }
            
            loopCounter++;
            // Check if the system is down, if it is up execute the following code for a maximum of 2 executions.
            if (sysDown==false && systemUpAfterFailureCount <= 2) 
            {
                // LOG ENTRY
                loopCounter = 0;
                // Send email for successful executions after a failure, limited to 2.
                if (systemUpAfterFailureCount <= 2)
                {
                    // EMAIL NOTIFICATION
                }
                // After two successful executions have occured, reset the counter
                if (systemUpAfterFailureCount == 2)
                {
                    systemUpAfterFailureCount = 0;
                }
            }
        }
