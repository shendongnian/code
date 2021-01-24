    static SizeDao()
    {
    	Mapper.Initialize(cfg => cfg.CreateMap<SizeEntity, Size>());
        // This is not needed.
    	// Mapper.Initialize(cfg => cfg.CreateMap<List<SizeEntity>, List<Size>>());
    }
