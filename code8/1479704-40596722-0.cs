    public class PersonProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Person, PersonDTO>().ReverseMap();
        }
    }
