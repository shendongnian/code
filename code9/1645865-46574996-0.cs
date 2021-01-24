    public int WaitForItem(int timeout){
       try{
           int nReturnCode = 0;
           int nTimeElapsed = 0;
           while (true)
           {
               if (mre.WaitOne(1000))  //just wait for  1 second
               {
                   nReturnCode = 1; //Set call on ManualResetEvent
                   break;
               }
               else  //Timeout need to repeat
               {
                   nTimeElapsed += 1000;
                   if (nTimeElapsed > timeout)
                   {
                       nReturnCode = 0; //timeout
                       break;
                   }
               }
           }
           return nReturnCode;
       }catch(ObjectDisposedException){
           return -1; //Exception 
       }
  }
