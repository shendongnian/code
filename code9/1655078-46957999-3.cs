     var timerSemaphore = new SemaphoreSlim(1)
     private void check_voice_call_State_cb(object obj)
     {
         var gotLock = timerSemaphore.Wait(0);
         if(!gotLock)
         {
             //Another instance of the timer callback is running, just return.
             return;
         }
         try
         {
             outputdata = SystemUtil.trace_proc(OnlineData.ADB_PATH, "-s " + 
                OnlineData.ADB_serial[PhoneNum] + @" shell ""dumpsys 
                telephony.registry | grep mCallState""");
             //Move this to inside the finally bock to make this happen even on a exception.
             Voice_call_state_timer.Change(2000, System.Threading.Timeout.Infinite); 
         }
         finally
         {
             timerSemaphore.Release();
         }    
    }
