    class Login
    {
         private Thread performThread;
         public static ManualResetEvent ResetEvent { get; set; }
         public bool Login(Userinfo)
         {
            // do tasks like authenticate
            if(authenticationValid)
            {
                PerformLoginAsyncThread(UserInfo);
                //continue to homepage
            }
        }   
        private void PerformLoginAsyncThread(UserInfo)
        {
            ResetEvent.Reset();
            performThread = new Thread(() => 
            {
                //do stuff
                ResetEvent.Set();
            });
            performThread.Start();
        }
    }
    
    class HomePage
    {
        public void OnClickFindProduct
        {
            bool finishedPostLoginThread = Login.ResetEvent.WaitOne(8000);
            if(finishedPostLoginThread)
            {
                // proceed to Find Product page
            }
            else
            {
                //If taking more than 8 seconds, throw message and exit app
            }
        }
    }
