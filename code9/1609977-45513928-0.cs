    //...
    double lastRow = range.Rows.Count;
    bgw.ReportProgress(-1, lastRow); // Just to set the Maximum value
    //...
    //...
    //int ultimaRiga = (int)lastRow;
    //int percents = (i * 100) / ultimaRiga;
    bgw.ReportProgress(i); // Just send the actual value / step
    //...
    //...
    void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
    	if (e.ProgressPercentage == -1)
    	{
    		progressBar1.Maximum = (int)e.UserState;
    		progressBar1.Value = 0;
    	}
    	else
    		progressBar1.Value = e.ProgressPercentage;
    }
    //...
