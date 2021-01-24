    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
        goOnPolling = false;
        for(int i=0;i<10;i++)
        {
            Application.DoEvents();
            Thread.Sleep(50);
        }
        //foreach (Thread element in activeThreadlist)
        //    if (element.IsAlive)
        //        element.Abort();
    }
