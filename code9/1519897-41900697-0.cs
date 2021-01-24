    public class MyViewModel : IValidatableObject
    {
    [Required]
    public DateTime StartDate { get; set; }
    [Required]
    public DateTime EndDate { get; set; } = DateTime.Parse("3000-01-01");
    
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            int result = DateTime.Compare(StartDate , EndDate);
            if (result < 0)
            {
                yield return new ValidationResult("start date must be less than the end date!", new [] { "ConfirmEmail" });
            }
        }
    }
