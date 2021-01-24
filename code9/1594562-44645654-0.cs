    AutoMapper.Mapper.Initialize(
    cfg =>
         {
            cfg.CreateMap<Alert, AlertModel>().ForMember(dest => dest.Sender, opt => opt.MapFrom(src => src.MessageSender));
            cfg.CreateMap<Recipient, RecipientModel>();
            cfg.CreateMap<Site, SiteModel>();
          }
    );
