	interface MyInterface<out T>
	{
		void OpenFile();
	}
	class Plug : Part
	{ }
	class Part
	{ }
	class BasePartViewModel<T> : MyInterface<T>
	{
		public void OpenFile()
		{
			throw new NotImplementedException();
		}
	}
	class Program
	{
		static void Main(string[] args)
		{
			BasePartViewModel<Plug> derived = new BasePartViewModel<Plug>();
			MyInterface<Part> b = derived;
			b.OpenFile();
		}
	}
