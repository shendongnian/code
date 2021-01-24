     public class ClientMappingProfile : Profile
     {
         public ClientMappingProfile ()
         {
             CreateMap<R_Logo, LogoDto>().ReverseMap();
         }
     }
