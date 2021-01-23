    public class SampleActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            //Provides information about an action method, such as its name, controller, parameters, attributes, and filters.
            var actionDescriptor = context.ActionDescriptor;
 
            //Gets the controller instance containing the action.
            var controller = context.Controller; 
            // Gets the arguments to pass when invoking the action. Keys are parameter names.
            var actionArgs = context.ActionArguments; 
        }
        
        ...
    }
