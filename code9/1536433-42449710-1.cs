        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            DateTime? dateValue = value as DateTime?;
            var memberNames = new List<string>() {context.MemberName};
            if (dateValue != null)
            {
                if (dateValue.Value.Date > DateTime.UtcNow.Date)
                {
                    return new ValidationResult(Resources.PastDateValidationMessage, memberNames);
                }
            }
            return ValidationResult.Success;
        }
    }
