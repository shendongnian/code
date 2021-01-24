    // singletone
    builder.RegisterInstance(new TaskRepository())
       .As<ITaskRepository>();
    // or instance based creation
    builder.Register(c => new LogManager(DateTime.Now))
       .As<ILogger>();
