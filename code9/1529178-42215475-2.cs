    public class MyBootstrapper : MefBootstrapper
    {
        protected override DependencyObject CreateShell()
        {            
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(MyBootstrapper).Assembly));
            var container = new CompositionContainer(catalog);
            var shell = container.GetExport<MainWindow>().Value;
            shell.Show();
            return shell;
        }
    }
