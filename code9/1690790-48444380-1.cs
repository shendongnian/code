    public static class AutoMapperConfig
    {
      public static MapperConfiguration ConfigureMapping()
      {
        return new MapperConfiguration(cfg =>
        {
          cfg.CreateMap<Person, PersonViewModel>();
          cfg.CreateMap<Order, OrderViewModel>();
        });
      }
    }
