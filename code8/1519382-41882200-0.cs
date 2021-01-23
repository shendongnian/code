    public  class Class1
    {
      public static int DummyWork(DateTime previoustime, IProgress<DateTime> progress = null)
      {
        for (int i = 0; i <= 100;)
        {
          if ((DateTime.Now - previoustime).Milliseconds >= 500)
          {
            progress?.Report(DateTime.Now);
          }
          //delay without using task.delay
          for (int myCounter = 0; myCounter < 50000000;)
          {
            myCounter++;
          }
        }
        return 1;
      }
    }
