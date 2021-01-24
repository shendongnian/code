	var config = new MapperConfiguration(cfg =>
	{
		cfg.CreateMap<ImageDetail, Image>();
		cfg.CreateMap<ProductModel, Product>()
			.ForMember(dest => dest.Images, opt => opt.MapFrom(src => src.ImageSet.ImageDetails))
			;
	});
