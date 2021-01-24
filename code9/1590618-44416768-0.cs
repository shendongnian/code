    private void bw_DoWork(object sender, DoWorkEventArgs e)
    {
        bool onLine = false;
        Stopwatch chrono = new Stopwatch();
        chrono.Start();
        while (chrono.ElapsedMilliseconds < 2000)
        {
            if (!State().Equals(Online))
            {
                System.Threading.Thread.Sleep(250);
            }
            else
            {
                onLine = true;
                break;
            }
        }
        e.Result = onLine;
    }
