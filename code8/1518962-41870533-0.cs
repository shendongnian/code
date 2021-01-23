    public class DalToServiceProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<DAL.Client, Interface.Model.Client>();
            CreateMap<DAL.Installation, Interface.Model.Installation>();
            CreateMap<DAL.Contract, Interface.Model.Contract>();
        }
    }
