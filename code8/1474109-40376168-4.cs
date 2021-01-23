	public struct EnumWrapper<T> where T : struct, IConvertible
	{
		public T? Enum { get; set; }
		public int? EnumValue => this.Enum?.ToInt32(CultureInfo.CurrentCulture.NumberFormat);
	}
	public static class EnumWrapperExtension
	{
		public static EnumWrapper<T> Wrap<T>(this T data) where T : struct, IConvertible
		{
			if (!typeof(T).IsEnum)
				throw new ArgumentException("T must be an enumerated type");
				
			return new EnumWrapper<T> { Enum = data };
		}
	}
