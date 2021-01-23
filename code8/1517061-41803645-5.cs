    if (Id == "Poll")
    {
        gateway.EnterReadLock();
        try
        {
            Console.WriteLine("Reply: " + poll.A + " " + poll.B + " " + poll.C + " " + poll.D + " " + poll.E);
            json = JsonConvert.SerializeObject(poll, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, Formatting = Formatting.Indented });
        }
        finally
        {
            gateway.ExitReadLock();
        }
    }   
