	public class Field<T>
	{
		public Expression<Func<T, object>> FieldName { get; set; }
	}
	public class FValue<T, F> : Field<T>
	{
		public F FieldValue { get; set; }
	}
