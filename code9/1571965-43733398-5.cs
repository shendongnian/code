	public class Element
	{
		public Type ArrayType { get; private set; }
		public string Value { get; private set; }
		public int Index { get; private set; }
		
		public Element(Type type, string value, int index)
		{
			ArrayType = type;
			Value = value;
			Index = index;
		}
	}
