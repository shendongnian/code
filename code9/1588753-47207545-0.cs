	public class MyCustomValidator : PropertyValidator
	{
		public MyCustomValidator()
			: base("{PropertyName} must do something.") { }
		protected override bool IsValid(PropertyValidatorContext context)
		{
			// Removed for brevity
			return true;
		}
	}
