    builder.RegisterGeneric(typeof(Service.EntityService<>))
      .As(typeof(Common.IEntityService<>))
      .Named(Common.ConfigType.ProjectType.Main,typeof(Common.IEntityService<>))
      .InstancePerDependency();
    builder.RegisterGeneric(typeof(LogProject.Service.EntityService<>))
      .As(typeof(ILogEntityService<>))
      .Named(Common.ConfigType.ProjectType.Log, typeof(Common.IEntityService<>))
      .InstancePerDependency();
