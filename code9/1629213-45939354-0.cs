    public class AsyncActionFilter : IAsyncActionFilter
    {
         public AsyncActionFilter(IEntityContext entityContext)
         {
             _entityContext = entityContext;
         }
         public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
         {  
              //Handle the request
              await next();
         }
    }
