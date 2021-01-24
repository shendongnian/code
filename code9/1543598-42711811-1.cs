    public static expectedwaittime;
    public static void OnMessageReceived(object sender, MessageReceivedEventArgs e)
    {
        try
        {
            if (e == null)
                return;
            if (e.CmsData != null)        
            /* ... */
            expectedwaittime = e.CmsData.Skill.ExpectedWaitTimeMedium.ToString();
            Console.WriteLine("your estimated wait time is " + expectedwaittime);
            /* ... */
        }
        catch { /* ... */ }
    }
