    public class Validator : IValidator
    {
        public IEnumerable<ErrorInfo> Validate(object instance)
        {
            IEnumerable<ErrorInfo> errores = from property in instance.GetType().GetProperties()
                from error in GetValidationErrors(instance, property)
                select error;
            if (!errores.Any())
            {
                errores = from val in instance.GetAttributes<ValidationAttribute>(true)
                    where
                        val.GetValidationResult(null, new ValidationContext(instance, null, null)) !=
                        ValidationResult.Success
                    select
                        new ErrorInfo(null,
                            val.GetValidationResult(null, new ValidationContext(instance, null, null)).ErrorMessage,
                            instance);
            }
            return errores;
        }
        public IEnumerable<ErrorInfo> Validate(object instance, string propertyName)
        {
            PropertyInfo property = instance.GetType().GetProperty(propertyName);
            return GetValidationErrors(instance, property);
        }
        private IEnumerable<ErrorInfo> GetValidationErrors(object instance, PropertyInfo property)
        {
            var context = new ValidationContext(instance, null, null);
            context.MemberName = property.Name;
            IEnumerable<ErrorInfo> validators = from attribute in property.GetAttributes<ValidationAttribute>(true)
                where
                    attribute.GetValidationResult(property.GetValue(instance, null), context) !=
                    ValidationResult.Success
                select new ErrorInfo(
                    property.Name,
                    attribute.FormatErrorMessage(property.Name),
                    instance
                    );
            return validators.OfType<ErrorInfo>();
        }
    }
