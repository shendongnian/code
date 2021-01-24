    public class EmptyModelValidator : IObjectModelValidator {
        public void Validate(
            ActionContext actionContext, 
            ValidationStateDictionary validationState,
            string prefix,
            object model) {
        }
    }
