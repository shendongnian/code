    public void publicLogMessage(string message)
    {
    	if (InvokeRequired)
    		Invoke(new OutputDelegate(logMessage), message);
    	else 
    		logMessage(message);
    }
    
    public delegate void OutputDelegate(string message);
    private void logMessage(string message)
    {
    	lblog.Items.Add(DateTime.Now + "  " + message);
    }
