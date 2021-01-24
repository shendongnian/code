	public static class AttributeExtensions {
		public static TResult GetEnumAttributeValue<TEnum, TAttribute, TResult>(this TEnum value,
		   Func<TAttribute, TResult> valueFunc)
			where TAttribute : Attribute
			where TEnum : struct, IComparable, IFormattable {
			var field = typeof(TEnum).GetField(value.ToString());
			if (field == null) {
				return default(TResult);
			}
			var attribute = field.GetCustomAttribute<TAttribute>();
			if (attribute == null) {
				return default(TResult);
			}
			return valueFunc.Invoke(attribute);
		}
	}
	
