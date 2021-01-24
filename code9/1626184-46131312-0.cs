    public class ValidatorInterceptor : IInterceptor
    {
        private readonly IServiceFactory factory;
        public ValidatorInterceptor(IServiceFactory _factory)
        {
            factory = _factory;
        }
        public void Intercept(IInvocation invocation)
        {
            var methodParameterSet = invocation.InvocationTarget.GetType().GetMethod(invocation.Method.Name).GetParameters().ToList();
            for (var index = 0; index < methodParameterSet.Count; index++)
            {
                var parameter = methodParameterSet[index];
                var paramType = parameter.ParameterType;
                var customAttributes = new List<object>();
                var factoryMethod = factory.GetType().GetMethod("GetService");
                var baseValidatorType = typeof(IValidator<>);
                var validatorType = baseValidatorType.MakeGenericType(paramType);
                factoryMethod = factoryMethod.MakeGenericMethod(validatorType);
                var validator = factoryMethod.Invoke(factory, null);
                customAttributes.AddRange(parameter.GetCustomAttributes(true).Where(item => item.GetType().Name.StartsWith("Validate")));
                foreach (var attr in customAttributes)
                {
                    dynamic attribute = attr;
                    var method = validator.GetType().GetMethod("Validate");
                    method = method.MakeGenericMethod(paramType);
                    object[] parameterSet = {invocation.Arguments[index], attribute.Rule, attribute.IsNullCheck};
                    method.Invoke(validator, parameterSet);
                }
            }
            invocation.Proceed();
        }
    }
