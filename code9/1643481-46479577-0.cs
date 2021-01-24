    private void bw_DoWork(object sender, DoWorkEventArgs e)
    {
    	try
    	{
    		while (true)
    		{
    			if (bw.CancellationPending)
    				break;
    
    			do_state_machine();
    			Thread.Sleep(100);
    		}
    	}
    	catch (Exception ex)
    	{
    		Console.WriteLine(ex.Message);
    	}
    }
