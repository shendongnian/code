    [Test]
    public void AutoMapperConfigurationInitializeValid()
    {
       AutoMapperConfiguration.Initialize();
       AutoMapperConfiguration.MapperConfiguration.AssertConfigurationIsValid();
    }
