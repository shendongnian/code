    public class MainClass {
		public static void Main (string[] args)
		{
			var a = new Base<List<string>>()
			{
				Value = new List<string> { "one", "two", "three" },
			};
			var serialized = TypeSerializer.SerializeToString(a);
			var deserialized = TypeSerializer.DeserializeFromString<DummyBase<List<string>>>(serialized);
			// no longer throws a null ref exception
			Console.WriteLine(deserialized.Value.Count);
		}
	}
	public class DummyBase<T> {
		public T Value { get; set; }
	}
	public class Base<T> : Base
	{ 
		public new T Value {
			get {
				return (T)base.Value;
			}
			set { base.Value = value; }
		}
	}
	public class Base
	{
		public object Value { get; set; }
	}
