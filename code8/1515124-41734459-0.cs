    public struct Foo
    {
        public object obj;
        public Foo(int val)
        {
            obj = new {
                bar = val
            };
			this.Use(new { bar = 0 }, x => Console.WriteLine(x.bar));
        }
		public void Use<T>(T prototype, Action<T> action)
		{
			action((T)this.obj);
		}
    }
