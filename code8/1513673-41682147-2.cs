    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
    
          ...
          builder.RegisterControllers(typeof(WebApiApplication).Assembly);
          builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);
        }
    }
