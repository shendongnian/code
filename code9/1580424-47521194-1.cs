        public class AutoMapperConfiguration
        {
            public static void Configure()
            {
                Mapper.Initialize(x =>
                {
                    x.AddProfile<MappingProfile>();
                });
                Mapper.Configuration.AssertConfigurationIsValid();               
            }
        }
