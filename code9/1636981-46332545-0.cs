    char ESC = (char)27;
    char CR = (char)13;
    char LF = (char)10;
    StringBuilder sb = new StringBuilder();
    
    //in my case, the data im expected is ended with a Line Feed (LF)
    //so I'll key on LF before I send my message
    private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
    {
        string Data = serialPort1.ReadExisting();
    
        foreach (char c in Data)
        {
            if (c == LF)
            {
                sb.Append(c);
    
                this.Invoke(new EventHandler(sb.toString()));
            }
            else
            {
    			//else, we append the char to our string that we are building
                sb.Append(c);
            }
        }
    }
