    public class MyTestModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Modules.AbpAutoMapper().UseStaticMapper = false;
            Configuration.Modules.AbpAutoMapper().Configurators.Add(config =>
            {
                config.CreateMap<TestDetailsDTO, Test>();
                config.CreateMap<Test, TestDetailsDTO>();
            });
        }
    }
