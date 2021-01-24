	public class Foo
	{
		public int Bar
		{
			get { return 2; }
			set { /* do nothing */ }
		}
	}
    /* … */
    Foo foo = new Foo();
	Console.WriteLine(foo.Bar = 23);
