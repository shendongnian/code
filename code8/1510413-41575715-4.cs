    public class BaseClass
	{
		public DateTime DateCreated { get; protected set; } //only protected because that's what I need...
		
		public BaseClass()
		{
			DateCreated = DateTime.Now;
		}
		
		public BaseClass(int year, int month, int day)
  		{
			DateCreated = new DateTime(year, month, day);
  		}
		
	}
	
	public class DerivedClass : BaseClass
	{
		public DerivedClass()
  		{
  		}
		
		public DerivedClass(DateTime dateTime)
			: base(dateTime.Year, dateTime.Month, dateTime.Day)
  		{
  		}
	}
