    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Conversation.UpdateContainer(builder =>
            {
                builder.RegisterModule(new DialogModule());
                builder.RegisterModule<BotModule>();
                builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            });
    
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(Conversation.Container);
    
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
