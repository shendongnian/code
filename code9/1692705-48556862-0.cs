    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            DependencyResolver.SetResolver(
                new StructureMapDependencyResolver(IoC.Container));
        
            IoC.Container.Configure(cfg =>
            {
    		   ...
            });
        
            using (var container = IoC.Container.GetNestedContainer())
            {
                foreach (var task in container.GetAllInstances<IRunAtInit>())
                {
                    task.Execute();
                }
        
                foreach (var task in container.GetAllInstances<IRunAtStartup>())
                {
                    task.Execute();
                }
            }
    	}
    }
