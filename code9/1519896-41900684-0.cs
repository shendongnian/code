    public class CompareDates : ValidationAttribute
    {
        protected override ValidationResult
                IsValid(object value, ValidationContext validationContext)
        {
            //get your startdate & end date from model and value
            //perform comparison
            if (StartDate < EndDate)
            {
                return new ValidationResult
                    ("start date must be less than the end date");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
