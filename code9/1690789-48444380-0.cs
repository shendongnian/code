    public static class AutoMapperConfig
    {
      return new MapperConfiguration(cfg =>
      {
        cfg.CreateMap<Person, PersonViewModel>();
        cfg.CreateMap<Order, OrderViewModel>();
      };
    }
