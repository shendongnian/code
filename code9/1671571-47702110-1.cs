    public class DemoBootstrapper : DefaultNancyBootstrapper
    {
      protected override void ConfigureConventions(NancyConventions conventions)
      {
        base.ConfigureConventions(conventions);
        
        conventions.StaticContentsConventions.Add(
            StaticContentConventionBuilder.AddDirectory("wwwroot")
        );
      }
    }
