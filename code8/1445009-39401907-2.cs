    class simpleClass1
	{
		public DateTime Date;
		public int AnotherField;
	}
	class simpleClass2
	{
		public DateTime Date2;
		public int AnotherField;
	}
    public List<object> GetResultList()
    {    		    			
        var listOfObjects = new List<object>{new simpleClass1 {Date = DateTime.MinValue, AnotherField = 2},new simpleClass2 {Date2 = DateTime.MinValue, AnotherField = 2}};
		return listOfSimpleClasses.Where(x =>
		{
			if (x is simpleClass2)
				return (x as simpleClass2).Date2 == DateTime.MinValue;
			if (x is simpleClass1)
				return (x as simpleClass1).Date == DateTime.MinValue;
			return false;
		}).ToList();
    }
