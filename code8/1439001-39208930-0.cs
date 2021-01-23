    Thread t1 = new Thread(o =>
    {
        while (true)
        {
            try
            {
                UpdateResult();
            }
            catch (Exception)
            {
                // do some error handling
            }
            Thread.Sleep(100);
        }
    });
