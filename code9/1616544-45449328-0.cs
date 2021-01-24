    char ESC = (char)27;
    char CR = (char)13;
    char LF = (char)10;
    StringBuilder sb = new StringBuilder();
    
    private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
    {
    	string Data = serialPort1.ReadExisting();
    
    	foreach (char c in Data)
    	{
    		if (c == LF)
    		{
    			sb.Append(c);
    
    			//we have our message, do something, maybe like
    			if (sb.ToString().Contains("A"))
    			{
    				//print A
    			}
    			else
    			{
    				//print B
    			}
    		}
    		else
    		{
    			sb.Append(c);
    		}
    	}
    }
