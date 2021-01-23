    public class CustomValidationAttributeAdapterProvider : IValidationAttributeAdapterProvider
    {
        private IValidationAttributeAdapterProvider innerProvider = new ValidationAttributeAdapterProvider();
        public IAttributeAdapter GetAttributeAdapter(ValidationAttribute attribute, IStringLocalizer stringLocalizer)
        {
            if (attribute == null)
                throw new ArgumentNullException(nameof(attribute));
            var type = attribute.GetType();
            if (type == typeof(CustomRequiredAttribute))
                return new RequiredAttributeAdapter((RequiredAttribute)attribute, stringLocalizer);
            return innerProvider.GetAttributeAdapter(attribute, stringLocalizer);
        }
    }
