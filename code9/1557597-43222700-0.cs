        try
        {
            Task.Factory.StartNew(() => throw new Exception("hi")).Wait();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
