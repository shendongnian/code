    internal class SomeObject{ //in C# you can even NOT to define internal as well :)
	public class next{
		public string ref {get; set;} //var do not use $, you need to change the JSON code or you nned to make a custom reader for that.
	}
	
	public List<Item> items {get; set;}
	
	public class Item{
		public string empno {get; set;}
		public string ename {get; set;}
		public string job {get; set;}
		public string mgr {get; set;}
		public string sal {get; set;}
		public string deptno {get; set;}
	}
    }
