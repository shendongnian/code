    public static void WriteLine(string message)
    {
        foreach (TraceListener listener in Listeners)
        {
            listener.WriteLine(message);
            if (AutoFlush) 
            {
                listener.Flush();
            }
        }                        
    }
