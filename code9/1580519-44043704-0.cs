    public void RunTwoThingsAtOnce()
    {
        new Thread( () =>
        {
            while (timeSpan > TimeSpan.Zero)
            {
                program.timer();
                //Input Block
            }
            
         }).Start();
   }
