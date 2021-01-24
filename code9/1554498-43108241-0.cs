    public void AddDataMethod(String s)
    {
    	this.Invoke((MethodInvoker)delegate
    	{
    		int i = 0;
    		txtSerial.AppendText(s + "\n");
    
    		if (s.Contains("stat:3") || s.Contains("Stop"))
    		{
    			globalSingleTon.Singleton.wickController.stageReady = true;
    		}
    
    		if (s.Contains("pos"))
    			{................
    		:
    		:
    	});
    }
