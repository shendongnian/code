     private void check_voice_call_State_cb(object obj)
     {
          var handle = new ManualResetEvent(false);
          var disposed = Voice_call_state_timer.Dispose(handle);
          if(!disposed)
          {
                //This is a extra firing of the event, we should not process further.
                return.
          }
          handle.WaitOne(); //Wait for the dispose to finish here.
          outputdata = SystemUtil.trace_proc(OnlineData.ADB_PATH, "-s " + 
                OnlineData.ADB_serial[PhoneNum] + @" shell ""dumpsys 
                telephony.registry | grep mCallState""");
    
          Voice_call_state_timer = new System.Threading.Timer(
               check_voice_call_State_cb,
               this, 
               2000,
               System.Threading.Timeout.Infinite); 
    
    }
