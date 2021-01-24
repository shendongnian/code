    // interface representing a class for resolving the error message
    public interface IErrorMessageResolver
    {
        // The attribute will call this method
        string ResolveErrorMessage(string propertyName, object value);
    }
    public class MessageResolverRequiredAttribute : RequiredAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult result = base.IsValid(value, validationContext);
            if (!result.Equals(ValidationResult.Success))
            {
                IErrorMessageResolver handler = validationContext.ObjectInstance as IErrorMessageResolver;
                if (handler == null)
                {
                    throw new Exception("Not validating an IErrorMessageResolver");
                }
                string customError = handler.ResolveErrorMessage(validationContext.MemberName, value);
                if (customError != null)
                {
                    result.ErrorMessage = customError;
                }
            }
            return result;
        }
    }
    public partial class TaskScheduling
        : IErrorMessageResolver
    {
        [MessageResolverRequired(MessageResolverType = typeof(MyMessageResolver))]
        public string SenderName { get; set; }
        public string ResolveErrorMessage(string propertyName, object value)
        {
            if (propertyName == "SenderName")
            {
                return "You need to set a Sender!";
            }
            return null;
        }
    }
