        public static void eventLogSubscription()
        {
            using (EventLog eventLog = new EventLog("Application"))
            {
                String path = Path.GetTempPath();
                eventLog.Source = "Event Log Reader Application";
                eventLog.WriteEvent(new EventInstance(1003, 0, EventLogEntryType.Information), new object[] { "The event log watcher has started" , path});
                //eventLog.WriteEntry(arg.EventRecord.ToXml(), EventLogEntryType.Information, 1001, 1);
                eventLog.Dispose();
            }
            EventLogWatcher watcher = null;
            try
            {
                string eventQueryString = "*[System/EventID=4688]" +
                                               "and " +
                                               "*[EventData[Data[@Name = 'NewProcessName'] = 'C:\\Windows\\explorer.exe']] )" +
            
                EventLogQuery eventQuery = new EventLogQuery(
                    "Security", PathType.LogName, eventQueryString);
                watcher = new EventLogWatcher(eventQuery);
                watcher.EventRecordWritten +=
                    new EventHandler<EventRecordWrittenEventArgs>(
                        handlerExplorerLaunch);
                watcher.Enabled = true;
                }
            }
            catch (EventLogReadingException e)
            {
                Console.WriteLine("Error reading the log: {0}", e.Message);
            }
            Console.ReadKey();
        }
        public static void handlerExplorerLaunch(object obj,
            EventRecordWrittenEventArgs arg)
        {            if (arg.EventRecord != null)
            {
                
                using (EventLog eventLog = new EventLog("Application"))
                {
                    eventLog.Source = "Event Log Reader Application";
                    eventLog.WriteEvent(new EventInstance(1001, 0, EventLogEntryType.Information), new object[] {arg.EventRecord.FormatDescription() });
                    //eventLog.WriteEntry(arg.EventRecord.ToXml(), EventLogEntryType.Information, 1001, 1);
                    eventLog.Dispose();
                }
            }
            else
            {
                Console.WriteLine("The event instance was null.");
            }
        }
