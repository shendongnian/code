    public void DataReceivedHandler(
                        object sender,
                        SerialDataReceivedEventArgs e)
    {
        if (trackbBar2.IsHandlecreated) trackBar2.Invoke(new Action(() =>  trackbar.Value = 50));
    }
