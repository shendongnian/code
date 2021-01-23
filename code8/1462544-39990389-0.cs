    public class RequiredInt32 : ValidationAttribute
    {
        private const string _customFormat = "{0} is not valid";
        private string _fieldName;
        public RequiredInt32(string fieldName)
			: base(_customFormat)
		{
            _fieldName = fieldName;
		}
        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, name);
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                if (Convert.ToInt32(value) == 0)
                {
                    return new ValidationResult(FormatErrorMessage(_fieldName));
                }
            }
            return ValidationResult.Success;
        }
    }
