    public class RuntimeMiddlewareService
    {
        private Func<RequestDelegate, RequestDelegate> _middleware;
        private IApplicationBuilder _appBuilder;
        internal void Use(IApplicationBuilder app)
        => _appBuilder = app.Use(next => context => _middleware(next)(context));
        public void Configure(Action<IApplicationBuilder> action)
        {
            var app = _appBuilder.New();
            action(app);
            _middleware = next => app.Use(_ => next).Build();
        }
    }
