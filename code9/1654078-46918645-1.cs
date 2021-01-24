    public HttpControllerDescriptor SelectController(HttpRequestMessage request)
    {
        IHttpRouteData routeData = request.GetRouteData();
        if (routeData == null)
        {
            throw new HttpResponseException(HttpStatusCode.NotFound);
        }
	    var genericControllerType = typeof(ListItemsController<>);
        // Get the namespace and controller variables from the route data.
        string typeParameterArgument = GetRouteVariable<string>(routeData, 'SomeKeyUsedToDecideTheClosedType');
	    Type typeArgument = //Somehow infer the generic type argument based on your route value
        Type[] typeArgs = { typeof(Item) };
        //obtain the closed generyc type
		var t = d1.MakeGenericType(typeArgs);			
   
        //configuration must be an instance of HttpConfiguration, most likeley you would inject this on the activator constructor on the config phase
		new HttpControllerDescriptor(_configuration, t.Name, t); 
       
    }
