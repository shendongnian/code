	public class Foo
	{
		public Foo()
		{
			_update = () => a == b && c != d;
		}
	
		private Func<bool> _update;
		
		private string a;
		private string b;
		private string c;
		private string d;
		private string e;
		private string f;
		private string g;
		private string h;
	
		private void CheckUpdate()
		{
			if (_update())
			{
				/*do something here*/
			}
		}
	
		public string A { get { return a; } set { a = value; CheckUpdate(); } }
		public string B { get { return b; } set { b = value; CheckUpdate(); } }
		public string C { get { return c; } set { c = value; CheckUpdate(); } }
		public string D { get { return d; } set { d = value; CheckUpdate(); } }
		public string E { get { return e; } set { e = value; CheckUpdate(); } }
		public string F { get { return f; } set { f = value; CheckUpdate(); } }
		public string G { get { return g; } set { g = value; CheckUpdate(); } }
		public string H { get { return h; } set { h = value; CheckUpdate(); } }
	}
