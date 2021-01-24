	void Main()
	{
		var strs = new List<string> { "A|B", "CCC|DD", "E|FFF"};
		
		var Ts = strs.Select(s =>s.ToT() );
		Ts.Dump();
	}
	
	static class Ext
	{
		static public T ToT(this string str)
		{
			return new T(str);
		}
	}
	
	public class T
	{
		public string A { get; set; }
		public string B { get; set; }
		
		public T(string str)
		{
			var arr= str.Split('|'); 
			A = arr[0];
			B = arr[1];
		}
	}
