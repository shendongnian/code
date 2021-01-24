    private static StandardKernel _kernel;
    private static object syncLock = new object();
    
    private static StandardKernel GetKernel() {
        if (_kernel == null) {
            lock(syncLock) {
                if (_kernel == null) {
                    System.Diagnostics.Debug.WriteLine("Creating Kernel");
                    _kernel = new StandardKernel();
                    _kernel.Bind<IHttpModule().To<HttpApplicationInitializationHttpModule>();
                    _kernel.Load(new Services.ServiceModule());
                }
            }
        }
        return _kernel;
    }
    
    
    public void ConfigureAuth(IAppBuilder app) {
        // Configure the db context, user manager and signin manager to use a single instance per request
        app.UseNinjectMiddleware(GetKernel);
        app.CreatePerOwinContext<MyApp.Dal.IDataAccessService>(() => 
        {
           return GetKernel().Get<MyApp.Dal.IDataAccessService>();
        });
        //... lots more config stuff
    }
