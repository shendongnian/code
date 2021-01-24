    // interface representing a class for resolving the error message
    public interface IErrorMessageResolver
    {
        // The attribute will call this method
        string ResolveErrorMessage(string propertyName, object value);
    }
    public class MessageResolverRequiredAttribute : RequiredAttribute
    {
        // Stores the type responsible for resolving the error message
        public Type MessageResolverType { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // call the built-in RequiredAttribute validator
            ValidationResult result = base.IsValid(value, validationContext);
            // if not valid, attempt to get the custom error message
            if (!result.Equals(ValidationResult.Success))
            {
                if (this.MessageResolverType != null)
                {
                    // create the resolver and check it actually is a resolver
                    IErrorMessageResolver handler = Activator.CreateInstance(this.MessageResolverType) as IErrorMessageResolver;
                    if (handler == null)
                    {
                        throw new Exception("MessageResolverType is not an IErrorMessageResolver");
                    }
                    // get the custom error message, if returns null, don't override the built-in error message
                    string customError = handler.ResolveErrorMessage(validationContext.MemberName, value);
                    if (customError != null)
                    {
                        result.ErrorMessage = customError;
                    }
                }
            }
            return result;
        }
    }
    public partial class TaskScheduling
    {
        [MessageResolverRequired(MessageResolverType = typeof(MyMessageResolver))]
        public string SenderName { get; set; }
    }
