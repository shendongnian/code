    public IEnumerable<IAppModule> GetAppModules()
    {
        yield return this;
        yield return new SubSys1AppModule();
        yield return new SubSys2AppModule();
    }
