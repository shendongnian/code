    public static Dictionary<string, object> MailSettings { get; private set; }
    public void ConfigureServices(IServiceCollection services)
    {
        //ConfigureServices code......
        MailSettings = Configuration.GetSection("MailSettings").GetChildren()
                      .ToDictionary(x => x.Key, x => x.Value);
    }
