     //this is App.xaml.cs
        public partial class App : Application
        {
            protected override void OnStartup(StartupEventArgs e)
            {
                AutoMapperConfiguration.RegisterMappings();
                base.OnStartup(e);
            }
        }
    
    
        public static class AutoMapperConfiguration
        {
            public static void RegisterMappings()
            {
                // Other Mappings here
    
                AutoMapper.Mapper.CreateMap<Party, PartyDTO>();
    
                //More Mappings here ...
            }
        }
