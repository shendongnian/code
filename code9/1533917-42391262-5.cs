    public class CommandValidator : AbstractValidator<Command>, IValidatorInterceptor
    {
        public CommandValidator() { 
            // validation rules etc.
        }
        public ValidationContext BeforeMvcValidation(ControllerContext controllerContext, ValidationContext validationContext)
        {
            return validationContext;
        }
        public ValidationResult AfterMvcValidation(ControllerContext controllerContext, ValidationContext validationContext, ValidationResult result)
        {
            var command = validationContext.InstanceToValidate as Command;
            if (command != null) command.AlreadyValidated = true;
            return result;
        }
        
    }
