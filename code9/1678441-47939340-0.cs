    private void ProcessData()
    {    
        Data data = new Data();
    
        try
        {
            Processor processor = new Processor();
            processor.Process(data);
        }
        catch( Exception e )
        {
            CustomCode(e);
        }
    	
    	finally {
    		if (!data.IsProcessed) CustomCode();
    	}
    }
