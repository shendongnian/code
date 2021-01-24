    void Main()
    {
    	
        var result = MyTables
                    .Where(mc => mc.A1 == 1)
                    .ToDictionary(m => m.ID.ToString(), 
                                  m => m.A2.ToString());
        result.Dump();
    }
