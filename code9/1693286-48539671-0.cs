    CreateMap<Product, ViewModelProduct>()
        // other members will be mapped by convention, because they have the same name
        .ForMember(vm => vm.SortOrder, o => o.Ignore()) // to be set in controller
        .ForMember(vm => vm.Categories, o => o.MapFrom(src => src.InCategories));
    
    // needed to resolve InCategories -> Categories
    CreateMap<ViewModelCategoryWithTitle, ProductInCategory>();
