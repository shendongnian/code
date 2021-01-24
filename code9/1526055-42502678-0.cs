    HttpListener listener = (HttpListener)appBuilder.Properties["System.Net.HttpListener"];
    listener.AuthenticationSchemeSelectorDelegate = request =>
    {
       if (request.HttpMethod == "OPTIONS")
       {
           return AuthenticationSchemes.Anonymous;
       }
    };
