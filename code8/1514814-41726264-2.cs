	// https://blogs.msdn.microsoft.com/helloworld/2009/04/03/workaround-to-deserialize-true-false-using-xmlserializer/
	public struct BooleanAsString
	{
		public BooleanAsString(bool value = default(bool))
		{
			StringValue = null;
			Value = value;
		}
		public static implicit operator BooleanAsString(bool value)
		{
			return new BooleanAsString(value);
		}
		public static implicit operator bool(BooleanAsString value)
		{
			return value.Value;
		}
		[XmlIgnore]
		public bool Value
		{
			get { return Boolean.Parse(StringValue); }
			set { StringValue = value ? "True" : "False"; }
		}
		[XmlText]
		public string StringValue { get; set; }
	}
