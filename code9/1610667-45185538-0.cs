    var builder = new ContainerBuilder();
    builder
        //register our factory function
        .Register<Func<Type, IValidator>>(
            x =>
            {
                //get a reference to the scoped container
                //e.g. if this is a web app, each HTTP request will
                //spawn a child container used for the lifetime of that request
                var context = x.Resolve<IComponentContext>();
                return type => 
                {
                    //create our validator
                    var valType = typeof(Validator<>).MakeGenericType(type);
                    return (IValidator) context.Resolve(valType);
                }
            }
    )};
    public class ValidationProvider
    {
        readonly Func<Type, IValidator> _factory;        
        //Autofac will see this class requires our previously registered
        //function and inject this for us
        public ValidationProvider(Func<Type, IValidator> factory)
        {
            _factory = factory;
        }
    }
