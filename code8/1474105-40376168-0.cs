	public static class EnumWrapperExtension
	{
		public static EnumWrapper<T> Wrap<T>(this T data) where T : struct, IConvertible
		{
			return new EnumWrapper<T>
			{
				Enum = data
			};
		}
	}
