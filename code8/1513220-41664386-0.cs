    private void CheckTime()
    {
        while (!exitCondition) //So you can cleanly kill the thread before exiting the program.
           {
               if (nextCheck < DateTime.Now)
               {
                   DoAction();
                   nextCheck = DateTime.Now + TimeBetweenReposts;
               }
               Thread.Sleep(1000); //Can be tweaked depending on how close to your time it has to be.
           }
    }
