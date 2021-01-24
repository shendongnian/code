    builder.RegisterGeneric(typeof(Service.EntityService<>))
      .AsSelf()
      .Named(Common.ConfigType.ProjectType.Main,typeof(Common.IEntityService<>))
      .InstancePerDependency();
    builder.RegisterGeneric(typeof(LogProject.Service.EntityService<>))
      .AsSelf()
      .Named(Common.ConfigType.ProjectType.Log, typeof(Common.IEntityService<>))
      .InstancePerDependency();
