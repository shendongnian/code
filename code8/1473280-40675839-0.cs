        //Define strings for searching the eventlog.
        string lockEvent = "4800";
        string unlockEvent = "4801";
       
         //Define the Eventlog source you want (in this case it's Security)
        string LogSource = @"Security";
        
        //Add these together to make the full query for Lock and Unlock
        string LockQuery = " *[System/EventID=" + lockEvent + "]";
        string UnlockQuery = "*[System/EventID=" + unlockEvent + "]";
    
    
    //Return true if there is any locked events found.
    
        private bool CheckForLock()
        {
            //Create Eventlog Reader and Query
            var elQuery = new EventLogQuery(LogSource, PathType.LogName, LockQuery);
            var elReader = new System.Diagnostics.Eventing.Reader.EventLogReader(elQuery);
    
            //Create a list of Eventlog records and add the found records to this
            List<EventRecord> eventList = new List<EventRecord>();
                    for (EventRecord eventInstance = elReader.ReadEvent();
                        null != eventInstance; eventInstance = elReader.ReadEvent())
                    {
                       
                       eventlist.add(eventInstance);
    
                     }
        
              if(eventList.count > 0)
                  {
                      return true;
                  }
               else
                 { 
                     return false;
                 }
        
            }
