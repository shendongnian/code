    ..
    using Umbraco.Web;
    ..
    
    var idPage = 1234; // you should get this dynamically :)
    IPublishedContent page = Umbraco.TypedContent(idPage);
    var labelFailure = page.GetPropertyValue<string>("labelFailure");
