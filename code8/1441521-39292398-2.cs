    public void MyMethod()
    {
    	var newValues = PropertyB.Where(x => true);
    	PropertyA.Clear();
    	foreach (var value in newValues)
    	{
    		PropertyA.Add(value);
    	}
    }
