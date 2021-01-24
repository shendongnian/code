    public void GetPluginByTargetFramework(string framework) 
    {
       if (Plugins == null) return;
       foreach (var p in Plugins.Where(p => p.TargetFramework == framework))
         p.Action();
    }
