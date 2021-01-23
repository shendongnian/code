    void SafeUpdateResults()
    {
        while (true)
        {
            try { UpdateResults(); }
            catch (Exception e)
            {
                //track the Error if you want
                Console.WriteLine("t1-Error: " + e.Message);
            }
        }
    }
