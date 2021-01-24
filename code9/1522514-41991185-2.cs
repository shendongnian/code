	public class MyObject
	{
		public int thing_1 { get; set; }
		...
		int GetValue(int find)
		{
		   return (int)Dynamic.InvokeGet(this, "thing_" + find.ToString());
		}
	}
