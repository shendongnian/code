		/// <summary>
		/// Returns true is all the properties of the object are null, empty or "smaller or equal to" zero (for int and double)
		/// </summary>
		/// <param name="obj">Any type of object</param>
		/// <returns></returns>
		public static bool IsObjectEmpty(this object obj)
		{
			if (Object.ReferenceEquals(obj, null))
				return true;
			return obj.GetType().GetProperties()
				.All(x => IsNullOrEmpty(x.GetValue(obj)));
		}
		/// <summary>
		/// Checks if the property value is null, empty or "smaller or equal to" zero (for numeric types)
		/// </summary>
		/// <param name="value">The property value</param>
		/// <returns></returns>
		private static bool IsNullOrEmpty(object value)
		{
			if (Object.ReferenceEquals(value, null))
				return true;
			if (value.GetType().GetTypeInfo().IsClass)
				return value.IsObjectEmpty();
			if (value is string || value is char || value is short)
				return string.IsNullOrEmpty((string) value);
			if (value is int)
				return ((int) value) <= 0;
			if (value is double)
				return ((double) value) <= 0;
			if (value is decimal)
				return ((decimal) value) <= 0;
			if (value is DateTime)
				return false;
			// ........
			// Add all other cases that we may need
			// ........
			if (value is object)
				return value.IsObjectEmpty();
			var type = value.GetType();
			return type.IsValueType
				&& Object.Equals(value, Activator.CreateInstance(type));
		}
