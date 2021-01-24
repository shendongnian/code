	public class SharedModelValidator : AbstractValidator<YourSharedModel>
	{
		public SharedModelValidator()
		{
			CustomRule(BeValid)
		}
		public bool BeValid(ValidationErrors<YourSharedModel> validationFailures, YourSharedModel sharedModel, ValidationContext<YourSharedModel> validationContext)
		{
			for (var m in sharedModel.Models)
			{
				var result = YourValidationMethod(m);
				if (!result.Success)
				{
					validationFailures.AddFailureFor(x => m, result.ErrorMessage);
					return false;
				}
			}
			return true;
		}
		private YourValidationMethod(MyClass model)
		{
			// the code you have that actually validates
		}
	}
