    // Compose DI
    var container = new Container();
    IEnumerable<Assembly> assemblies = new[] { typeof(Program).Assembly };
    container.Register(typeof(IHoster<>), assemblies);
    container.Register(typeof(IConfigSourceValidator<>), assemblies);
    container.Register(typeof(IHosterApi<>), assemblies);
    container.Register(typeof(IBackupMaker<>), assemblies);
    var github = container.GetInstance<IHoster<GithubHoster>>();
    var bitbucket = container.GetInstance<IHoster<BitbucketHoster>>();
