    public static void WaitForTimeSpan(IApp app, TimeSpan timeSpan)
    {
        try
        {
            app.WaitForElement(c => c.Text("BLAH BLAH BLAH"), "Waiting for something, killing time", timeSpan);
        }
        catch (Exception)
        {
            //do nothing we just wanted to kill some time
        }
    }
