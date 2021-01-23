    if (CatelEnvironment.IsInDesignMode)
    {
        var viewModelLocator = ServiceLocator.Default.ResolveType<IViewModelLocator>();
        viewModelLocator.NamingConventions.Insert(0, "[UP].ViewModels.[VW]DesignTimeViewModel")
    }
