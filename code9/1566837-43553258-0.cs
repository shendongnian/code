    void Application_Start(object sender, EventArgs e)
    {
        BundleConfig.RegisterBundles(BundleTable.Bundles);
    
        //Use this if you want to force/test bundling in debug.
        BundleTable.EnableOptimizations = true;
    }
