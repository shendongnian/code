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
       
    }
}
