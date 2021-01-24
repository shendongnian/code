	public struct Int32 : IModifiable<Int32>
	{
		public System.Int32 Value { get; set; }
		public Int32 Modify(Int32 value)
		{
			return new Int32() { Value = Value + value.Value };
		}
	}
	public class String : IModifiable<String>
	{
		public System.String Value { get; set; }
		public String Modify(String value)
		{
			return new String() { Value = Value + value.Value };
		}
	}
