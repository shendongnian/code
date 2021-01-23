	public static class NumericFieldExtensions
	{
		public static NumericField SetIntValue(this NumericField f, int? value)
		{
			if (value.HasValue)
				f.SetIntValue(value.Value);
			else
				f.SetIntValue(int.MinValue);
			return f;
		}
	}
