        public class HomeController
        {
           public HomeController(IOptions<ApplicationSettings> appSettings)
           { ...
            appSettings.Value.UrlBasePath
            ...
            // or better practice create a readonly private reference
            }
         }
