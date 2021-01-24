    private static void RegisterServices(IKernel kernel)
    {
        kernel.Bind(x =>
        {
            x.FromThisAssembly()
             .SelectAllClasses()
             .BindDefaultInterface();
        });
        kernel.Bind(x =>
        {
            x.FromAssemblyContaining(typeof(IService))
             .SelectAllClasses()
             .BindDefaultInterface();
        });
        kernel.Bind(typeof(IEfRepository<>)).To(typeof(EfRepository<>));
        kernel.Bind(typeof(DbContext), typeof(MsSqlDbContext)).To<MsSqlDbContext>().InRequestScope();
        kernel.Bind<ISaveContext>().To<SaveContext>();
        kernel.Bind<IMapper>().ToMethod(ctx => AutoMapperConfig.MapperInstance);
    }
