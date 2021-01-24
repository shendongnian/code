     var validatorTypes = assemblies.SelectMany(a => a.GetTypes().Where(t =>
                t.IsClass && !t.IsAbstract && t.IsPublic &&
                t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IValidator<>)) &&
                !t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IProvideWarnings<>))
            )).ToList();
    
    IocContainer.Register(typeof(IValidator<>), validatorTypes, IocContainer.DefaultLifestyle);
     
    IocContainer.RegisterConditional(typeof(IValidator<>), typeof(ValidateNothingDecorator<>), Lifestyle.Singleton, c => !c.Handled && !c.ServiceType.DoesImplement(typeof(IProvideWarnings)));
