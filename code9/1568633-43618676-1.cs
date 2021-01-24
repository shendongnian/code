    public Form1()
    {
        // In this approach, you can get rid of the "mythread" field altogether
        myPort = new SerialPort("COM3", 9600);
        myPort.ReadTimeout = 3500;
        InitializeComponent();
        foreach (var t in Constants.ComboParameters)
            this.paramCombo.Items.Add(t);
        radioClose.CheckedChanged += new EventHandler(radioButtonCheckedChanged);
        radioOpen.CheckedChanged += new EventHandler(radioButtonCheckedChanged);
    }
    public async void radioButtonCheckedChanged(object sender,EventArgs e)
    {
        if (radioOpen.Checked && !myPort.IsOpen)
        {
            try
            {
                myPort.Open();
                await ReadFct();
                // Execution of this method will resume after the ReadFct() task
                // has completed. Which it will do only on throwing an exception.
                // This code doesn't have any continuation after the "await", except
                // to handle that exception.
            }
            catch (Exception)
            {
                // This block will catch the exception thrown when the port is
                // closed. NOTE: you should not catch "Exception". Figure out what
                // *specific* exceptions you expect to happen and which you can
                // handle gracefully. Any other exception can mean big trouble,
                // and doing anything other than logging and terminating the process
                // can lead to data corruption or other undesirable behavior from
                // the program.
                MessageBox.Show("Nu s-a putut deschide port-ul");
            }
            // Return here. We don't want the rest of the code executing after the
            // continuation, because the radio button state might have changed
            // by then, and we really only want this call to do work for the button
            // that was selected when the method was first called. Note that it
            // is probably even better if you just break this into two different
            // event handlers, one for each button that might be checked.
            return;
        }
        if (radioClose.Checked && myPort.IsOpen)
        {
            // Closing the port should cause `ReadLineAsync()` to throw an
            // exception, which will terminate the read loop and the ReadFct()
            // task
            myPort.Close();
        }
    }
