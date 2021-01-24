    public void DataReceivedHandler(
                        object sender,
                        SerialDataReceivedEventArgs e)
    {
        trackBar2.Invoke(new Action(() =>  trackbar.Value = 50));
    }
