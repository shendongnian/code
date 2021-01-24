    public class Bar<T>
    {
        public T Value { get; set; }
        public int Prop1 { get; set; }
        public int Prop2 { get; set; }
		
		public Bar(T value)
		{
			this.Value = value;
		}
    }
	
	var wrappedFoo1 = Bar<Foo1>(new Foo1());
	var wrappedFoo2 = Bar<Foo2>(new Foo2());
