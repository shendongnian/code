    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ...
            SwaggerConfig.Register(config);
        }
