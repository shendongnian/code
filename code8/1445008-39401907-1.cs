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
    public List<dynamic> GetResultList()
    {    			
            var listOfSimpleClasses = new List<dynamic> {new simpleClass1 {Date = DateTime.MinValue, AnotherField = 2}, new simpleClass2 {Date2 = DateTime.MinValue, AnotherField = 2}};
			return listOfSimpleClasses.Where(x =>
			{
				if (x is simpleClass2)
					return x.Date2 == DateTime.MinValue;
				if (x is simpleClass1)
					return x.Date == DateTime.MinValue;
				return false;
			}).ToList();
