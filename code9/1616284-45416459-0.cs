    public void callpopup(String number) {
         checkThread();
    //answer, decline or something else
   
    }
       
    [MethodImpl(MethodImplOptions.Synchronized)]
        public static void checkThread()
        {
            try
            {
                if (ep != null && !ep.libIsThreadRegistered())
                    ep.libRegisterThread(Thread.CurrentThread.Name);
            }
            catch (Exception e)
            {
               
            }
        }
