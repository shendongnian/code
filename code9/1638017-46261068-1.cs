    public void GetPluginByTargetFramework(string framework) 
    {
        frameworkPlugs = Plugins.Where(p => p.TargetFramework == framework)
                                .ToList().ForEach(p => p.Action());
    }
