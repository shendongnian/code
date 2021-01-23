    public class Startup2 {
        public void Configuration(IAppBuilder appBuilder) {
            var encryptedContent = "Hello World";
            var decryptedString = "\"Hello From OWIN\"";
            appBuilder.Use<DecryptionMiddleWare>(encryptedContent, decryptedString);
            //Configure Web API middleware
            var config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            appBuilder.UseWebApi(config);
        }
    }
