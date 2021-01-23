    var mvcContext = context.Resource as 
        Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext;
    if (mvcContext != null)
    {
        // Examine MVC specific things like routing data.
    }
