    StringBuilder sb = new StringBuilder();
    char LF = (char)10;
    
    private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
    {
    	string Data = serialPort1.ReadExisting();
    
    	foreach (char c in Data)
    	{
    		if (c == LF)
    		{
    			sb.Append(c);
    
    			CurrentLine = sb.ToString();
    			sb.Clear();
    			
    			//do something with your response 'CurrentLine'
                Eval_String(CurrentLine);
    		}
    		else
    		{
    			sb.Append(c);
    		}
    	}
    }
