    @using Microsoft.AspNetCore.Http
    @inject Microsoft.AspNetCore.Http.IHttpContextAccessor HttpContextAccessor
    @{
        string value = HttpContextAccessor.HttpContext.Session.GetString("value");
    }
