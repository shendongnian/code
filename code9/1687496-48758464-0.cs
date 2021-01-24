    public class ValidateModelStateFilter : ActionFilterAttribute, IAutofacActionFilter
    {
        private readonly IValidatorFactory _factory;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="factory"></param>
        public ValidateModelStateFilter(IValidatorFactory factory)
        {
            _factory = factory;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="actionContext"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            base.OnActionExecutingAsync(actionContext, cancellationToken);
            IEnumerable<object> parameters = actionContext.ActionArguments.Select(x => x.Value).Where(x => x != null);
            foreach (var parameter in parameters)
            {
                Type argumentType = parameter.GetType();
                if (argumentType == typeof(int) || argumentType == typeof(string))
                {
                    continue;
                }
                IValidator validator = _factory.GetValidator(argumentType);
                if (validator != null)
                {
                    ValidationResult validationResult = validator.Validate(parameter);
                    if (!validationResult.IsValid)
                    {
                       // place your formatting logic here. 
                        actionContext.Response = <your formatted response>;
                    }
                }
            }
            return Task.FromResult(0);
        }
        /// <summary>
        /// Creates formatted response message which contains validation errors in API-friendly format
        /// </summary>
        /// <param name="validationResult"></param>
        private ErrorsModel CreateFormattedApiResponse(ValidationResult validationResult)
        {
            var errorsModel = new ErrorsModel();
            IEnumerable<ErrorModel> formattedErrors = validationResult.Errors.Select(error =>
            {
                var errorModel = new ErrorModel();
                var errorState = error.CustomState as ErrorState;
                if (errorState != null)
                {
                    errorModel.ErrorCode = errorState.ErrorCode;
                    errorModel.Field = error.PropertyName;
                    errorModel.DeveloperMessage = string.Format(errorState.DeveloperMessageTemplate, error.PropertyName);
                    errorModel.UserMessage = errorState.UserMessage;
                }
                return errorModel;
            });
            errorsModel.Errors = formattedErrors;
            return errorsModel;
        }
    }
}
