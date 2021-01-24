    private void DataRecievedHandler(object sender, SerialDataReceivedEventArgs e)
    {
        try
        {
            SerialPort sp = (SerialPort)sender;
            string indata = sp.ReadExisting();
            Debug.Print("Data Received:");
            Debug.Print(indata);
            // Store to class scope property spReadMsg for the sendSMS method to read.
            spReadMsg = indata;
        }
        catch (Exception ex)
        {
            Debug.Print(ex.Message);          
        }
    }
