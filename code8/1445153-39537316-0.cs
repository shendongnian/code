    class Program
	{
		static void Main(string[] args)
		{
			var dbChild1ResultSet = new[]
			{
				new DbChild1()
				{
					Field1 = "1",
					Field2 = "2",
					DbChild1Field1 = "3"
				},
				new DbChild1()
				{
					Field1 = "11",
					Field2 = "22",
					DbChild1Field1 = "33"
				},
			};
			var guiChild1ResultSet = dbChild1ResultSet.Select(x => new GuiChild1(x)
			{
				GuiChild1Field1 = x.DbChild1Field1
			});
		}
	}
	public class Parent1
	{
		public string Field1 { get; set; }
		public string Field2 { get; set; }
		public Parent1()
		{
		}
		public Parent1(Parent1 toCopyFrom)
		{
			Field1 = toCopyFrom.Field1;
			Field2 = toCopyFrom.Field2;
		}
	}
	public class DbChild1 : Parent1
	{
		public string DbChild1Field1 { get; set; }
		public DbChild1()
		{
		}
		public DbChild1(Parent1 toCopyFrom) : base(toCopyFrom)
		{
		}
	}
	public class GuiChild1 : Parent1
	{
		public string GuiChild1Field1 { get; set; }
		public GuiChild1()
		{
		}
		public GuiChild1(Parent1 toCopyFrom) : base(toCopyFrom)
		{
		}
	}
