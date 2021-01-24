    public class AutoMapperProfile : Profile
    {
       public AutoMapperProfile() 
        {
            ConfigureMappings();
        }
        private void ConfigureMappings()
        {
           //  DriverModel and Driver mapping classes
           CreateMap<DriverModel, Driver>().ReverseMap();
        } 
    }
