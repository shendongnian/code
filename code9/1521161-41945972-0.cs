    public void Configuration(IAppBuilder app)
    {
        /// (...)
        app.RegisterForDisposal(_Container);
    }
