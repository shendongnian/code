    public static string AdjustTimezoneForDisplay(DateTime date)
    {
     //.......
    }
    public static void RegisterMaps()
    {
      Mapper.Initialize(config =>
      {
       config.CreateMap<EquipmentOther, KMEquipmentOthers>()
               .ForMember(x=>x.Status,opt=>opt.Ignore())
               .ForMember(x => x.CreatedOn, opt => opt.MapFrom(x => AdjustTimezoneForDisplay(x.CreatedOn)));
      }
    }
