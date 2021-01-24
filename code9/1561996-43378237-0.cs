    public class ValidatorFactory : IValidatorFactory
    {
      public ValidatorFactory(Func<Type, IValidator> factory) { _factory = factory; }
      private readonly Func<Type, IValidator> _factory;
    
    
      public IValidator create(object objectToValidate)
      {
        var validatorType = typeof(IValidator<>).MakeGenericType(new Type[] { objectToValidate.GetType() });
    
        return _factory(validatorType);
      }
    }
    
    public  static class YourBootstrapperClass{
    
        public static void Register(ContainerBuilder containerBuilder){
    
            containerBuilder.Register(ctx => new ValidatorFactory(type => { 
                    object validator;
                    containerBuilder.TryResolve(validatorType, out validator);
                    return validator;
             })).As<IValidatorFactory>();
        }
    }
