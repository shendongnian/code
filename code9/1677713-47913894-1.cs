    class Bootstrapper : UnityBootstrapper
    {
       protected override void ConfigureContainer()
       {
          base.ConfigureContainer();
          RegisterTypeIfMissing(typeof(ICommonService), 
             typeof(CommonService), true); // true for register as singleton
       }
         
       protected override void ConfigureModuleCatalog()
       {
          base.ConfigureModuleCatalog();
          ModuleCatalog module_catalog = (ModuleCatalog)this.ModuleCatalog;
          module_catalog.AddModule(typeof(SomeModule));
       }
    }
