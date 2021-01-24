    void Main()
    {
    	
        var result = MyTables
                    .Where(mc => mc.A1 == 1)
                    .ToDictionary(m => m.ID, 
                                  m => m.A2);
        result.Dump();
    }
