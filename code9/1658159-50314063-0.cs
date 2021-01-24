    public class MyMappingProfile : Profile
    {
        public MyMappingProfile()
        {
            // define your mapping here, for example:
            CreateMap<RegionViewModel, Region>().ReverseMap();
            CreateMap<CountryViewModel, Country>().ReverseMap();
        }
    }
