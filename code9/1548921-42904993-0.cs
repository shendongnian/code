        public class AutoMapping
        {
            internal static void Init()
            {
                 Mapper.CreateMap<BankDto, BankViewModel>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.BankId))
                .ForMember(dst => dst.InstitutionBankId, opt => opt.MapFrom(src => src.InstitutionBankId));
            }
        }
