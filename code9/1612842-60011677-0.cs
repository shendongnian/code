	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class DateBetweenAgesAttribute : ValidationAttribute {
		public int MinProperty { get; set; }
		public int MaxProperty { get; set; }
		public DateBetweenAgesAttribute(int min, int max) : base() {
			MinProperty = min;
			MaxProperty = max;
			ErrorMessage = $"Your age is not between {MinProperty} and {MaxProperty}";
		}
	}
