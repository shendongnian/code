    public List<object> TableList()
    {
        List<object> list = new List<object>();
    
        _cmd.CommandText = "SELECT * FROM sys.tables";
    
        try
        {
            _read = _cmd.ExecuteReader();
        }
        catch (Exception e)
        {
                         //please ignore this try catch for now
            list[0] = e; //this is a temporary measure until I finalize error handling
        }
        _read.Read(r => list.Add(r.GetValue(0)));        
        _read.Close();
    
        return list;
    }
