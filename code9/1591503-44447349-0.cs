    // Arrange.
    var configuration = new HttpConfiguration();
    var request = new System.Net.Http.HttpRequestMessage();
    request.Properties[System.Web.Http.Hosting.HttpPropertyKeys.HttpConfigurationKey] = configuration;
    //...other code
