    public void SyncFadeOut()
    {
         // define how many fade-steps you want
         for (int i = 0; i < 1000; i ++)
         {
             System.Threading.Thread.Sleep(10); // pause thread for 10 ms
             // ----
             // do the incremental fade step here
             // ----
         }
    }
