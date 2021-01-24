	public class Element
	{
		public Type ArrayType { get; private set; }
		public string Value { get; private set; }
		
		public Element(Type type, string value)
		{
			ArrayType = type;
			Value = value;
		}
	}
