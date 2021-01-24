    cfg.CreateMap<Product, Models.Product>()
    .ForMember(m => m.Provider, opt => opt.Ignore())
    .MaxDepth(1)
    .ReverseMap();
    cfg.CreateMap<Provider, Models.Provider>()
    .AfterMap((src, dest) =>
    {
        foreach (var i in dest.Product)
            i.Provider = dest;
    })
    .MaxDepth(1)
    .ReverseMap();
