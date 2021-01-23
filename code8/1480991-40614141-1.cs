    for (int i = 0; i <= 9999; i++)
    {
        LogManager.GetCurrentClassLogger().Info("this is for testing " + i);
    }
    LogManager.Flush(); //flushes all async targets and block until done. There is also an optional timeout.
    Console.Write("done");
