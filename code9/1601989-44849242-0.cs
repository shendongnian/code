    public class SmallRectangle : IValidatableObject
    {
        public uint Width { get; set; }
        public uint Height { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var area = Width * Height;
            if (area > 37)
            {
                yield return new ValidationResult($"The rectangle is too large.");
            }
        }
    }
