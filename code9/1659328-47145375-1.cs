    static void Main() {
	  List<IFoo<object>> items = new List<IFoo<object>>();
	  items.Add(new Foo<string>() { MyItem = "Hello" });
      // not possible because int is a value type
	  // items.Add(new Foo<int>() { MyItem = 123 }); 
    }
	
	interface IFoo<out T>
	{
		T MyItem {get;}
	}
	class Foo<T> : IFoo<T>
	{
		public T MyItem {get;set;}
	}
