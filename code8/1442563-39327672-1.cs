      public class CacheWebApiAttribute : ActionFilterAttribute
      {
          public int Duration { get; set; }
 
          public override void OnActionExecuted(HttpActionExecutedContext    filterContext)
           {
              filterContext.Response.Headers.CacheControl = new CacheControlHeaderValue()
              {
                 MaxAge = TimeSpan.FromMinutes(Duration),
                 MustRevalidate = true,
                 Private = true
              };
            }
          }
