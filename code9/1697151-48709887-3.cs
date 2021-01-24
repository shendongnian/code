    public void Startup()
    {
        var catalog = new AggregateCatalog();  
        catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
        var container = new CompositionContainer(catalog);
        var parentViewModel = container.GetExportedValue<ParentViewModel>();
        parentViewModel.Show();
    }
