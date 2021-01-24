	private static void ValueError(HttpActionContext context, string requirement) {
	    var httpConfiguration = context.RequestContext.Configuration;
		var resolver = httpConfiguration.DependencyResolver;
		var logger = resolver.GetService(typeof(ILogger));
		var action = context.ActionDescriptor.ActionName;
		logger.LogError($"{action} Failed : Missing Required Attribute {requirement}. ");
		using (var controller = new BaseApiController { Request = new HttpRequestMessage() }) {
		    //USE THE GLOBAL HTTPCONFIGURATION ALREADY ASSOCIATED WITH THE
            //REQUEST INSTEAD OF CREATING A NEW ONE THAT HAS NONE OF THE 
            //WEB API CONFIG THAT WOULD HAVE BEEN ADDED AT STARTUP
			controller.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, httpConfiguration);
			context.Response = controller.InvalidInputResponse();
		}
	}
	
