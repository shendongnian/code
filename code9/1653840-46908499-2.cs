    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = true)]
    sealed class RequiredIfAttribute : ValidationAttribute
    {
        readonly string boolPropertyName;
        public RequiredIfAttribute(string boolPropertyName)
        {
            this.boolPropertyName = boolPropertyName;
            throw new NotImplementedException();
        }
        public string BoolPropertyName
        {
            get { return boolPropertyName; }
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var prop = validationContext.ObjectType.GetProperty(BoolPropertyName);
            if (prop == null)
            {
                throw new ValidationException("Property not found: " + BoolPropertyName);
            }
            var condition = prop.GetValue(validationContext.ObjectInstance) as bool?;
            if (condition == true && string.IsNullOrEmpty(value as string))
            {
                return new ValidationResult("Required: " + validationContext.MemberName);
            }
            return ValidationResult.Success;
        }
    }
