    public static Dictionary<string, object> MailSettings { get; private set; }
    public void ConfigureServices(IServiceCollection services)
    {
        //ConfigureServices code......
        MailSettings = 
            Configuration.GetSection("MailSettings").GetChildren()
            .Select(item => new KeyValuePair<string, string>(item.Key, item.Value))
            .ToDictionary(x => x.Key, x => x.Value);
    }
