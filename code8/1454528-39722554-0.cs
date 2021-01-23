    public string VersionLabel
            {
                get
                {
                    if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
                    {
                        Version ver = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion;
                        return string.Format("Product Name: {4}, Version: {0}.{1}.{2}.{3}", ver.Major, ver.Minor, ver.Build, ver.Revision, Assembly.GetEntryAssembly().GetName().Name);
                    }
                    else
                    {
                        var ver = Assembly.GetExecutingAssembly().GetName().Version;
                        return string.Format("Product Name: {4}, Version: {0}.{1}.{2}.{3}", ver.Major, ver.Minor, ver.Build, ver.Revision, Assembly.GetEntryAssembly().GetName().Name);
                    }
    
    
    
                }
            }
