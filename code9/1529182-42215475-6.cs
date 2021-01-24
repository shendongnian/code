        public class MyBootstrapper : MefBootstrapper
        {
            protected override AggregateCatalog CreateAggregateCatalog()
            {
                return new AggregateCatalog();
            }
    
            protected override void ConfigureAggregateCatalog()
            {
                AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(MyBootstrapper).Assembly));
            }      
    
            protected override CompositionContainer CreateContainer()
            {
                return new CompositionContainer(AggregateCatalog);
            }
    
            protected override void ConfigureContainer()
            {
                base.ConfigureContainer();
            }
    
            protected override DependencyObject CreateShell()
            {
                var shell = Container.GetExport<MainWindow>().Value;
                shell.Show();
                return shell;
            } 
        }
