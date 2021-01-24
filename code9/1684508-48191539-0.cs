            void keepAliveTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                client.isAlive();
            }
            catch (System.Exception ex)
            {
                eventLog1.WriteEntry(" [CRITICAL EXCEPTION in keepAliveTimer_Elapsed()]. WCf service is down, Kiosk Tray Agent is trying to send a heartbeat." + Environment.NewLine + "Caught an exception of type" + ex.GetType().Name, EventLogEntryType.Error, 912);
            }
            finally
            {
                ((System.Timers.Timer)sender).Start();
            }
        }
