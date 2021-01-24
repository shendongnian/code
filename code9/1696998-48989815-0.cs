    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            BotConfig.UpdateConversationContainer();
        }
    }
    public static class BotConfig
    {
        public static void UpdateConversationContainer()
        {
            var builder = new ContainerBuilder();
            builder
                .Register(c => new CachingBotDataStore(c.ResolveKeyed<IBotDataStore<BotData>>(typeof(ConnectorStore)), CachingBotDataStoreConsistencyPolicy.LastWriteWins))
                .As<IBotDataStore<BotData>>()
                .AsSelf()
                .InstancePerLifetimeScope();
            builder.Update(Conversation.Container);
        }
    }
