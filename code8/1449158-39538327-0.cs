        try
        {
            myTask.Wait();
        }
        catch(AggregateException ex)
        {
            var innerException = ex.InnerException;
            Console.Out.WriteLine("Exception of type " + innerException .GetType() + " caught, message: " + innerException.Message);
        }
