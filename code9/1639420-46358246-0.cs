    using (Session session = new Session())
    {
        int attempts = 3;
        do
        {
            try
            {
                session.Open(sessionOptions);
            }
            catch (Exception e)
            {
                Console.WriteLine("Failed to connect - {0}", e);
                if (attempts == 0)
                {
                    // give up
                    throw;
                }
            }
            attempts--;
        }
        while (!session.Opened);
        Console.WriteLine("Connected");
    }
