    var container = new Container();
    string baseUrl = System.Configuration.ConfigruationManager.AppSettings["URL"];
    if (string.IsNullOrEmpty(baseUrl))
        throw new ConfigurationErrorsException("appSettings/URL is missing.");
    container.RegisterSingleton<IApiClient>(new ApiClient(baseUrl));
