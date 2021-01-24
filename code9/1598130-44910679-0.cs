    finally
    {
        if (client != null)
            ((IDisposable)client).Dispose();
    }
    Console.WriteLine(DateTime.Now.ToString("h:mm:ss tt"));
