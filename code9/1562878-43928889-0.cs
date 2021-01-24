    HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
    if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
    {
        HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods",
                     "GET, POST, PUT, DELETE");
        HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers",
                     "Content-Type, Accept");
        HttpContext.Current.Response.End();
     }
