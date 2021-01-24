    public HttpControllerDescriptor SelectController(HttpRequestMessage request)
    {
        IHttpRouteData routeData = request.GetRouteData();
        if (routeData == null)
        {
            throw new HttpResponseException(HttpStatusCode.NotFound);
        }
        //get the generyc type of your controller
	    var genericControllerType = typeof(ListItemsController<>);
        // Get the route value from which you'll get the type argument from your controller.
        string typeParameterArgument = GetRouteVariable<string>(routeData, 'SomeKeyUsedToDecideTheClosedType');
	    Type typeArgument = //Somehow infer the generic type argument,  form your route value based on your needs
        Type[] typeArgs = { typeof(typeArgument) };
        //obtain the closed generyc type
		var t = genericControllerType.MakeGenericType(typeArgs);			
   
        //configuration must be an instance of HttpConfiguration, most likeley you would inject this on the activator constructor on the config phase
		new HttpControllerDescriptor(_configuration, t.Name, t); 
       
    }
