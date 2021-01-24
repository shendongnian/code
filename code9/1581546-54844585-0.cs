    HttpClient client = new HttpClient();
    ProductHeaderValue header = new ProductHeaderValue("MyAwesomeLibrary", Assembly.GetExecutingAssembly().GetName().Version.ToString());
    ProductInfoHeaderValue userAgent = new ProductInfoHeaderValue(header);
    client.DefaultRequestHeaders.UserAgent.Add(userAgent);
    // User-Agent: MyAwesomeLibrary/1.0.0.0
