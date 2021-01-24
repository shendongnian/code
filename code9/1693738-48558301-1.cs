    // Services.Dll
    public class ServicesRegistrion : Module
    {
      protected override void Load(ContainerBuilder builder)
      {
        builder.Register<MyClass>()
          .As<IMyInterface>()
          .InstancePerLifetimeScope();
      }
    }
