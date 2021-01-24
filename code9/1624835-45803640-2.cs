    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<NameDB>().As<INameDB>();
            builder.RegisterType<NameDB2>().As<INameDB2>();
            string assembly = "MY_ASSEMBLY";
            builder.RegisterAssemblyTypes(Assembly.Load(assembly)).Where(t => t.IsAssignableTo<IValidator>()).AsImplementedInterfaces();
            AutofacHostFactory.Container = builder.Build();
        }
    }
