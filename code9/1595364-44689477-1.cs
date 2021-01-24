    app.MapWhen(context => Regex.IsMatch(context.Request.Uri.PathAndQuery.ToLower(), @"/site"), newApp =>
    {
    #if !DEBUG
        newApp.Use<Middleware1>();
    #endif
        newApp.Use<Middleware2>();
    
        newApp.Use<Middleware3>(); // On the response path back, the IOwinResponse body is already empty
    });
