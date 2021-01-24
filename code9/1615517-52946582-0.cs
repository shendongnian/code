    [ImportMany] //  It allows us to import zero or more Exported items that match.	
    private IEnumerable<Lazy<IProvider, IMetaData>> _Providers;
    
    [Export] // This tag is required if you want to create an instance in the child class
    private readonly IFacade _iFacade;
    
    #region [ MEF Loading ]
    
    private void LoadPlugin()
    {
    var pluginsDirectoryPath = ConfigurationReader.PluginsDirectoryPath;
    if (System.IO.Path.IsPathRooted(pluginsDirectoryPath) == false)
    pluginsDirectoryPath =
    
    System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, pluginsDirectoryPath);
    
    pluginsDirectoryPath = System.IO.Path.GetFullPath(pluginsDirectoryPath);
    if (System.IO.Directory.Exists(pluginsDirectoryPath) == false)
    {
    throw new CriticalException(
    "The plugins directory path is not defined. Add Plugins parameter to configuration file.");
    }
    
    //An aggregate catalog that combines multiple catalogs
    var catalog = new AggregateCatalog();
    // Plgins only load from plugins directory for now
    catalog.Catalogs.Add(new DirectoryCatalog(pluginsDirectoryPath));
    
    //Create the CompositionContainer with the parts in the catalog
    var container = new CompositionContainer(catalog);
    
    //Fill the imports of this object
    try
    {
    container.ComposeParts(this);
    }
    catch (CompositionException compositionException)
    {
    throw new CriticalException("Unable to load authentication plugins", compositionException);
    }
    }
    #endregion [ MEF Loading ]
