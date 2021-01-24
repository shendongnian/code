    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    
    public class ValidateFileExtensionsAttribute : ActionFilterAttribute
    {
    
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var fileKeyValue = context.ActionArguments.FirstOrDefault(x => typeof(IFormFile).IsAssignableFrom(x.Value.GetType()));
    
            if (fileKeyValue.Value != null)
            {
                AppConfigurationManager sessionService = context.HttpContext.RequestServices.GetService(typeof(AppConfigurationManager)) as AppConfigurationManager;
                IFormFile fileArg = fileKeyValue.Value as IFormFile;
    
                if (!sessionService.AllowedFileUploadTypes.Keys.Any(x => x == fileArg.ContentType))
                {
                    context.Result = new ObjectResult(new { Error = $"The content-type '{fileArg.ContentType}' is not valid." }) { StatusCode = 400 };
    
                    //or you could set the modelstate
                    //context.ModelState.AddModelError(fileKeyValue.Key, $"The content-type '{fileArg.ContentType}' is not valid.");
                    return;
                }
            }
    
            await next();
        }
    }
