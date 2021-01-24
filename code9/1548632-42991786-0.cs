    public class AModule : Module
    {
      protected override void Load(ContainerBuilder builder)
      {
        builder.Register(c => new AComponent()).As<AComponent>();
      }
    }
    
    public class BModule : Module
    {
      protected override void Load(ContainerBuilder builder)
      {
        builder.Register(c => new BComponent()).As<BComponent>();
      }
    }
