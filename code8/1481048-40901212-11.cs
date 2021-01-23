    public MessageListener MessageListener { get; private set; }
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IApplicationLifetime appLifetime)
    {
        appLifetime.ApplicationStarted.Register(() =>
        {
            MessageListener = app.ApplicationServices.GetService<MessageListener>();
            MessageListener.Start();
        });
        appLifetime.ApplicationStopping.Register(() =>
        {
            MessageListener.Stop();
        });
        // ...
    }
