	public class MyCustomPropertyValidator : ClientValidatorBase, IClientModelValidator
    {
        public MyCustomPropertyValidator(PropertyRule rule, IPropertyValidator validator)
            : base(rule, validator)
        {
        }
        public override void AddValidation(ClientModelValidationContext context)
        {
            var validator = (MyCustomValidator)Validator;
            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-whatever", "...");
            // Add other attributes
        }
    }	
