    using System.Globalization;
    using System.Text.RegularExpressions;
    
    public class Record : IValidatableObject {
      
         public string Budget { get; set; }
    
         public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
    
            var currentDecimalSeparator =
                CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            
            // no need to espace literal dot '.' 
            // because it is used inside a character class '[.]'
            var currencyPattern = @"^[$]?\d+[" + currentDecimalSeparator + @"]?\d?\d? ?[€$]?$";
    
            if (!Regex.IsMatch(Budget, currencyPattern)) {
                 yield return new ValidationResult(
                     $"Invalid currency format (use '{currentDecimalSeparator}' for decimal places).",
                     new[] { "Budget" }
                 );
            }
         }
    }
