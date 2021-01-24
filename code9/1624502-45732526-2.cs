    private void SerialPortOnDataReceived(object sender, SerialDataReceivedEventArgs serialDataReceivedEventArgs)
        {
            if (IsFire)
            {
                
                    int dataLength = _serialPort.BytesToRead;
                    byte[] data = new byte[dataLength];
                    int nbrDataRead = _serialPort.Read(data, 0, dataLength);
                    if (nbrDataRead == 0)
                        return;
                    string str = System.Text.Encoding.UTF8.GetString(data);
    
                    double number;
                    bool success = false;
                    if (Double.TryParse(str, out number))
                    {
                        success = true;
                    }
                    else
                    {
                        var match = Regex.Match( str, @"\d+\.\d+");
                        if( match.Success )
                        {
                            success = Double.TryParse(match.Value, out number);
                        }
                    }
                
                    if( success )
                    {
                        SetText(number.ToString());
                  }
            }
        }
    delegate void SetTextCallback(string text);
    private void SetText(string text)
    {
        // InvokeRequired required compares the thread ID of the
        // calling thread to the thread ID of the creating thread.
        // If these threads are different, it returns true.
        if (this.txtBCGGrassWeight.InvokeRequired)
        {
            SetTextCallback d = new SetTextCallback(SetText);
            this.Invoke(d, new object[] { text });
        }
        else
        {
            this.txtBCGGrassWeight.Text = string.Format("{0:0.000}",text);
        }
    }
