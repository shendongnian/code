	public class AuthorizationFilter : IAsyncAuthorizationFilter
		{
			public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
			{
				var controllerActionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
				string controllerName = controllerActionDescriptor?.ControllerName;
				string actionName = controllerActionDescriptor?.ActionName;
			}
		}
