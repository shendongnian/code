    var inventoryService = new InventoryService();
    var modelNameResolver = new ModelNameResolver(inventoryService);
    Mapper.Initialize(c =>
    {
        c.CreateMap<Product, ProductViewModel>()
            .ForMember(dest => dest.Model, opt => opt.ResolveUsing(modelNameResolver));
    });
