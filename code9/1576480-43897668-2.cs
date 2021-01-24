    void Main()
    {    	
    	Container c = new Container();
    	
    	List<Macro> MacroList = new List<Macro>();
    	
    	for (int i = 0; i < 10; i++)
    	{
    		Macro m = new Macro();
    		if (i % 2 == 0)
    		{
    			m.action = c.turnOn;
    		}
    		else
    		{
    			m.action = c.turnOff;
    		}
    		
    		MacroList.Add(m);
    	}
    	
    	foreach (var m in MacroList)
    	{
    		m.Run();
    	}    	
    }
