    [TestMethod]
    public void AutoMapperConfigIsValid()
    {
      Mapper.Initialize(cfg => 
      {
        cfg.AddProfile<MappingProfile>();
        // add all profiles you'll use in your project here
      });
      Mapper.AssertConfigurationIsValid();
    }
