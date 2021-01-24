    public void GetPluginByTargetFramework(string framework) 
    {
        Plugins.Where(p => p.TargetFramework == framework)
               .ToList().ForEach(p => p.Action());
        //Better to use a foreach loop on the items returned from the where
    }
