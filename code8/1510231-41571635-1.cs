    var bw = new BackgroundWorker();
    bw.DoWork += Bw_DoWork;
    bw.RunWorkerCompleted += Bw_RunWorkerCompleted;
    bool wasError;
    ManualResetEvent e = null;
    private void TextBox_LostFocus(object sender, RoutedEventArgs e)
    {
        if (e != null)
            return;
        wasError = false;
        e = new ManualResetEvent(false); //not signaled
        bw.RunWorkerAsync(data1);
        e.Wait(); //much better than while(bw.Busy())
        if (!wasError)
           bw.RunWorkerAsync(data2);
        e = null;
    }
    private void Bw_DoWork(object sender, DoWorkEventArgs e)
    {
        //background work in another thread
    }
    private void Bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        if (e.Error != null)
        {
            //catch exception here
            wasError = true;
        }
        e.Set(); //switch to signaled
    }
