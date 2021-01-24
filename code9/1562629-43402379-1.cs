    private void button1_Click(object sender, EventArgs e)
    {
        Thread thread = new Thread(
        () =>
        {
            //  Perform work
            var retValue = LongRunningHeavyFunction();
            //  Call the GUI thread
            button1.Dispatcher.BeginInvoke(() =>
            {
                //  .Dispatcher called the GUI thread.
                //  This code happens back in the GUI thread once the
                //  worker thread has completed.
                button1.Text = retValue;
            });
        });
        thread.Start();
    }
    private string LongRunningHeavyFunction()
    {
        Thread.Sleep(5000);
        return "Done";
    }
