    public class MappingConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(config =>
            {
                config.AddProfile<GeneralMappingConfigProfile>(); 
                config.AddProfile<MeetingsMappingConfigProfile>();
                //etc
            });
        }
    }
