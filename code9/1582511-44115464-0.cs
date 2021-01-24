    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var context = new OwinContext(app.Properties);
            var token = context.Get<CancellationToken>("host.OnAppDisposing");
            if (token != CancellationToken.None)
            {
                token.Register(() =>
                {
                    // code to run at shutdown
                });
            }
        }
    }
