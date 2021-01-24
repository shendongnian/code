    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.Register(c => new IdentityFactoryOptions<ApplicationUserManager>()
            {
                DataProtectionProvider = app.GetDataProtectionProvider()
            }).SingleInstance();
            //Or
            //builder.Register<IDataProtectionProvider>(c =>app.GetDataProtectionProvider()).SingleInstance();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
