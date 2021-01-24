    [Serializable()]
    public class TextCustomInputValidator : ICustomInputValidator<string>
    {
        private int MinLength, MaxLength;
        public TextCustomInputValidator(int minLength, int maxLength)
        {
            MinLength = minLength;
            MaxLength = maxLength;
        }
        public bool IsValid(string input)
        {
            return input.Length >= MinLength && input.Length <= MaxLength;
        }
    }
