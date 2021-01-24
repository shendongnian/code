    container.RegisterType<BaseSearchProvider, SettingsOneSearchProvider>("SettingsOne"
    		new HierarchicalLifetimeManager(),       
    		new InjectionFactory(c =>ExamineManager.Instance.SearchProviderCollection["Setting 1"]));
    
    
    container.RegisterType<BaseSearchProvider, SettingsTwoSearchProvider>("SettingsOne"
    		new HierarchicalLifetimeManager(),
    		new InjectionFactory(c => ExamineManager.Instance.SearchProviderCollection["Setting 2"]));
