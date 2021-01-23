    public void BeginOperation() 
    {    
        try
        {
            DoSync();
        }    
        catch (Exception x)
        {
            Log(x.message)
            Show(x.message);   
        }
    }
    public void DoSync() 
    {    
        try
        {
            GetSampleDatatable();
            ApplyDiff();
            CommitDiff();
        }    
        catch (Exception x)
        {
            Log(x.message);
            throw x;  
        }
    }
