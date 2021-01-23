    var ps = new ProductSize { UnitSize = 10, Name = "Good Product" };
        
    AutoMapper.Mapper.Initialize( x => 
       x.CreateMap<ProductSize, ProductDto>()
       .ForMember( t => t.UnitSize, opt => opt.MapFrom(y => y.UnitSize) )
       .ForMember( t => t.Name, opt => opt.MapFrom(y => y.Name)));
    var dto = AutoMapper.Mapper.Map<ProductSize, ProductDto>( ps );
             
    Console.WriteLine( dto.UnitSize );
    Console.WriteLine( dto.Name );
