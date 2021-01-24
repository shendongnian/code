    public static IServiceCollection DisableDefaultModelValidation(this IServiceCollection services)
    {
      ServiceDescriptor serviceDescriptor = services.FirstOrDefault<ServiceDescriptor>((Func<ServiceDescriptor, bool>) (s => s.ServiceType == typeof (IObjectModelValidator)));
      if (serviceDescriptor != null)
      {
        services.Remove(serviceDescriptor);
        services.Add(new ServiceDescriptor(typeof (IObjectModelValidator), (Func<IServiceProvider, object>) (_ => (object) new EmptyModelValidator()), ServiceLifetime.Singleton));
      }
      return services;
    }
    public class EmptyModelValidator : IObjectModelValidator
    {
      public void Validate(ActionContext actionContext, ValidationStateDictionary validationState, string prefix, object model)
      {
      }
    }
