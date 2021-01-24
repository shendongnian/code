    public T GetHoster<T>() where T: IHoster
    {
        var validator = Ioc.ResolveAll<IConfigSourceValidator>().Where(x => x.GetType().GetCustomAttribute<HosterAttribute>().Type == typeof(T)).Single();
        var hosterApi = Ioc.ResolveAll<IHosterApi>().Where(x => x.GetType().GetCustomAttribute<HosterAttribute>().Type == typeof(T)).Single();
        var backupMaker = Ioc.ResolveAll<IBackupMaker>().Where(x => x.GetType().GetCustomAttribute<HosterAttribute>().Type == typeof(T)).Single();
    
        var hoster = Ioc.Resolve<T>(validator, hosterApi, backupMaker);
        return hoster;
    }
