    HttpContext.Current = new HttpContext(
        new HttpRequest("", "http://tempuri.org", ""),
        new HttpResponse(new StringWriter())
        );
    
    // User is logged in
    HttpContext.Current.User = new GenericPrincipal(
        new GenericIdentity("username"),
        new string[0]
        );
    
    // User is logged out
    HttpContext.Current.User = new GenericPrincipal(
        new GenericIdentity(String.Empty),
        new string[0]
        );
