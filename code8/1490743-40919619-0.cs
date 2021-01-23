        ManualResetEvent isWaitOver = new ManualResetEvent(false);
        private void Run()
        {
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string Badge = Database.GetString(row, "Badge");
                if (Badge.Length > 0)
                {
                    if (Count < Controller.MaximumBadges)
                    {
                        if (processed == 100) // Every 100 downloads, pause for a second
                        {
                            processed = 0;
                            StartTimer();
                            isWaitOver.WaitOne();
                            Controller.PostRecordsDownloadedOf("Badges", Count);
                        }
                        if (Download(Badge, false))
                        {
                            Count++;
                            processed++;
                        }
                    }
                    else
                        Discarded++;
                }
                TotalCount++;
            }
        }
        private void StartTimer()
        {
            // Create a timer with a one second interval.
            aTimer = new System.Timers.Timer(1000);
            // Hook up the Elapsed event for the timer.
            isWaitOver.Reset();
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }
        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            aTimer.Enabled = false;
            isWaitOver.Set();
        }
