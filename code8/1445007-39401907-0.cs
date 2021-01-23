    public interface IClassWithDate
	{
		DateTime DateForFiltering();
	}
	internal class classDerrivedFromInterface1 : IClassWithDate
	{
		public DateTime Date;
		public int AnotherField;
		public DateTime DateForFiltering()
		{
			return Date;
		}
	}
	internal class classDerivvedFromInterface2 : IClassWithDate
	{
		public DateTime Date2;
		public int AnotherField;
		public DateTime DateForFiltering()
		{
			return Date2;
		}
	}
    public List<IClassWithDate> GetResultList<IClassWithDate>()
    {    			
        var listOfIClassesWithDate = new List<IClassWithDate> { new classDerrivedFromInterface1 { Date = DateTime.MinValue, AnotherField = 2 }, new classDerivvedFromInterface2 { Date2 = DateTime.MinValue, AnotherField = 2 } };
		return listOfSimpleClasses.Where(x => x.DateForFiltering() == DateTime.MinValue).ToList();
    }
