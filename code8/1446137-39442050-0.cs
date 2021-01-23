    public class Phone
    {
        // no more required attributes here
        public string Mobile { get; set; }
        public string Office { get; set; }
    }
    public class Physician : IValidatableObject
    {
        [Required]
        public Phone ContactPhone { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(string.IsNullOrWhiteSpace(ContactPhone.Mobile))
            {
                yield return new ValidationResult("Mobile number is required");
            }
            if (string.IsNullOrWhiteSpace(ContactPhone.Office))
            {
                yield return new ValidationResult("Office number is required");
            }
        }
    }
    public class Patient : IValidatableObject
    {
        [Required]
        public Phone ContactPhone { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(ContactPhone.Mobile))
            {
                yield return new ValidationResult("Mobile number is required");
            }
        }
    }
