     namespace YourProject.Common.DataAnnotations
        {
            [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
            public sealed class ValidateCreateDateAttribute : ValidationAttribute
            {
                private const string _defaultErrorMessage = "Date is requierd, value most be after or on today's date.";
                public ValidateCreateDateAttribute()
                {
                    if (string.IsNullOrEmpty(ErrorMessage))
                    {
                        ErrorMessage = _defaultErrorMessage;
                    }
                }
                protected override ValidationResult IsValid(object value, ValidationContext validationContext)
                {
                    if (value != null)
                    {
                        Type type = value.GetType();
                        if (type.IsPrimitive && (type == typeof(DateTime) || type == typeof(DateTime?)))
                        {
                            var checkDate = Convert.ToDateTime(value);
                            //in UTC, if you are using timezones, use user context timezone
                            var today = DateTime.UtcNow.Date;
                            //compare datetimes
                            if (DateTime.Compare(checkDate, today) < 0)
                            {
                                return new ValidationResult(ErrorMessage);
                            }
                            //success
                            return ValidationResult.Success;
                        }
    return new ValidationResult("Cannot validate a non datetime value");
                    }
                    //if value cannot be null, you are using nullable date time witch is a paradox
                    return new ValidationResult(ErrorMessage);
                }
            }
        }
