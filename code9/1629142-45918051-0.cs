    protected override IEnumerable<Assembly> AndroidViewAssemblies => new 
    List<Assembly>(base.AndroidViewAssemblies)
    {
    	typeof(MvxRecyclerView).Assembly
    };
