     public class ValidateViewModelAttribute : ActionFilterAttribute
            {
                public override void OnActionExecuting(ActionExecutingContext actionContext)
                {
                    if (actionContext.ActionArguments.Any(x => x.Value == null))
                    {
                        actionContext.Result = new BadRequestObjectResult(HttpStatusCode.BadRequest);
                        
                    }
    
                    if (actionContext.ModelState.IsValid == false)
                    {
                        actionContext.Result = new BadRequestObjectResult(HttpStatusCode.BadRequest);
                    }
                }
            }
