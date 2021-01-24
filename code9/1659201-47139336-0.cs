    using System.ComponentModel.DataAnnotations;
    using System.Web;
    
    public class MyViewModel : IValidatableObject {
    
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
    
            var sessionValue = HttpContext.Current.Session["abc"];
    
            yield return new RequiredAttribute {
                ErrorMessage = "error message: required"
            }.GetValidationResult(sessionValue, validationContext);
    
            const string pattern = "^([a-zA-Z0-9]+)$";
            yield return new RegularExpressionAttribute(pattern) {
                ErrorMessage = "error message: regex"
            }.GetValidationResult(sessionValue, validationContext);
        }
    }
