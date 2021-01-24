        /// <summary>
        /// WriteLog - Overloaded Method to write a Message. 
        /// </summary>
        /// <param name="LogType">LogLevel.Trace
        /// LogLevel.Debug,
        /// LogLevel.Info,
        /// LogLevel.Warn,
        /// LogLevel.Error,
        /// LogLevel.Fatal,</param>
        /// <param name="Msg">Message to write</param>
        /// <param name="args">Arguments</param>
        public void WriteLog(LogLevel LogType, String Msg, object[] args)
        {
            try
            {
                if (args == null)
                    args = new object[0];
                LogEventInfo logEvent = new LogEventInfo(LogType, GetCallingMethodName(), null, String.Format(Msg, args), null);
                if (PortNumber != 0)
                    logEvent.Properties["PortNumber"] = ".Line_" + PortNumber;
                Instance.Log(typeof(Logging), logEvent);
                //Instance.Log((LogLevel)LogType, Msg, args);
            }
            catch (Exception) { throw; }
        }
