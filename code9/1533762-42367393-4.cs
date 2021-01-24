    public static class AppMapper
    {
        public static MapperConfiguration Mapping()
        {
            return new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Customer, CustomerTO>()
                    .ForMember(dest => dest.CustId, opt => opt.MapFrom(src => src.CustomerId))
                    .ForMember(dest => dest.CustData, opt => opt.MapFrom(src => src.CustName))
                    .ForMember(dest => dest.CustomerJson, opt => opt.MapFrom(src => JsonConvert.DeserializeObject(src.CustomerJson));
                });
        }
    }
