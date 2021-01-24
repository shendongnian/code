    public class HexColorAttribute : ValidationAttribute
    {
        private string _errorMessage;
    
        public ClassicMovieAttribute(string errorMessage)
        {
            _errorMessage = errorMessage
        }
    
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var colorHexStr = (string)value;
            var valid = Regex.IsMatch(colorHexStr, "#[0-9a-fA-F]{6}");
            if(valid)
            {
                  return ValidationResult.Success;
            }
            else
            {
                  return new ValidationResult(_errorMessage)
            }
    
        }
