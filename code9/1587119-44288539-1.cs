    using System.Web.Http;
    using System.Web.Routing;
    using System.Web.Http.Controllers;
    using System.Web;
    using System.Web.Http.Filters;
    using System.Linq;
    using System.Collections.Generic;
    
    namespace TestValidation
    {
    	internal class ValidateModelStateFilterAttribute : ActionFilterAttribute
    	{
    		public override void OnActionExecuting(HttpActionContext actionContext)
    		{
    			if (!actionContext.ModelState.IsValid)
    			{
    				string errorMessage = string.Empty;
    
    				List<string> errors = new List<string>();
    
    				try
    				{
    					errors = actionContext.ModelState.Values.SelectMany(val => val.Errors.Select(err => err.ErrorMessage)).ToList();
    
    					errorMessage = string.Join(";", errors);
    				}
    				catch    				{
    					errorMessage = "Validation failed on input";
    				}
    
    				throw new HttpException(422, errorMessage);
    			}
    		}
    	}
    }
