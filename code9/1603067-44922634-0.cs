     //Mapper Class
     public partial class AutoMapperConfig
     {
      public static MapperConfiguration UserLoginTovmLogin = null;
      public static void Mappings()
        {
            UserLoginTovmLogin = new MapperConfiguration(cfg =>
            cfg.CreateMap<User_Login, VmLogin>()
            .ForMember(conf => conf.LoginId, dto => dto.MapFrom(src => src.Login_Id))
            .ForMember(conf => conf.Passsword, dto => dto.MapFrom(src => src.Passsword)));
        }
      }
       //In your Data login class
       VmLogin IAuthRepository.Login(string loginId)
        {
            VmLogin login = new VmLogin();
            var result = //Your Data Logic
            AutoMapperConfig.UserLoginTovmLogin.CreateMapper().Map(result, login);
            return login; 
        }
