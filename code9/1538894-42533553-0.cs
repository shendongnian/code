    namespace InSumma_Servicebus.App_Start
    {
        public partial class Startup
        {
            public void Configuration(IAppBuilder app)
            {
                WebApiConfig.Register(new HttpConfiguration());
                ConfigureAuth(app);
            }
        }
    }
