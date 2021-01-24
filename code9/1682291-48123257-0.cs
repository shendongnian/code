    private StringBuilder sb;
    private SerialPort sp;
    
    public void init_state_machine()
    {
    	sp = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
    	sp.DataReceived += new SerialDataReceivedEventHandler(sp_DataReceived);
    
    	sb = new StringBuilder();
    	sb.Clear();
    }
    		
    private void sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
    {
    	string currentLine = "";
    	string Data = sp.ReadExisting();
    
    	Data.Replace("\n", ""); //remove new lines
    
    	foreach (char c in Data)
    	{
    		if (c == '\r')
    		{
    			currentLine = sb.ToString();
    			sb.Clear();
    			
    			Console.WriteLine(currentLine);
    		}
    		else
    		{
    			sb.Append(c);
    		}
    	}
    }
