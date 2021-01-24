    DateTime starttime;
    private void backgroundWorker1_DoWork(
        object sender, System.ComponentModel.DoWorkEventArgs e)
    {
        int sum = 0;
        // Using UtcNow will ensure the time calculation is correct even if
        // the work occurs during a daylight saving time change-over
        starttimme = DateTime.UtcNow;
        for (int i = 1; i <= 100; i++)
        {
            // run the process here
           Thread.Sleep(100);
            // end process
            sum = sum + i;
            backgroundWorker1.ReportProgress(i);
            if (backgroundWorker1.CancellationPending)
            {
                e.Cancel = true;
                backgroundWorker1.ReportProgress(0);
                return;
            }
        }
        // displays the sum of the process
        e.Result = sum;
    }
    private void backgroundWorker1_ProgressChanged(
        object sender, System.ComponentModel.ProgressChangedEventArgs e)
    {
        progressBar1.Value = e.ProgressPercentage;
        label5.Text = e.ProgressPercentage.ToString() + "%";
        var timespent = DateTime.UtcNow - starttime;
        // Casting to double here is superfluous. TotalSeconds is already a
        // double, and its presence in the expression results in the rest of
        // the values being promoted to double and the expression type being double.
        double secondsremaining =
            (double)(timespent.TotalSeconds / progressBar1.Value) *
            (progressBar1.Maximum - progressBar1.Value);
        label7.Text = "Time remaining:" + (int)secondsremaining;
        Console.WriteLine(secondsremaining);
    }
