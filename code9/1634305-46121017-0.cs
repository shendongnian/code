    public void ConfigureAuth(IAppBuilder app)
    {
        MyContext Create() { return new MyContext(); }
        app.CreatePerOwinContext(Create);
        ...
    }
