    public class ValidateMe : IValidatableObject
    {
        [Required]
        public bool Enable { get; set; }
        [Range(1, 5)]
        public int Prop1 { get; set; }
        [Range(1, 5)]
        public int Prop2 { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!this.Enable)
            {
                /* Return valid result here.
                * I don't care if Prop1 and Prop2 are out of range
                * if the whole object is not "enabled"
                */
            }
            else
            {
                 /* Check if Prop1 and Prop2 meet their range requirements here
                 * and return accordingly.
                 */ 
            }
        }
    }
