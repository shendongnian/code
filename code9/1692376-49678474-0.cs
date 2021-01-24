    var collection = new ServiceCollection();
	collection.AddOData();
	collection.AddODataQueryFilter();
	collection.AddTransient<ODataUriResolver>();
	collection.AddTransient<ODataQueryValidator>();
	collection.AddTransient<TopQueryValidator>();
	collection.AddTransient<FilterQueryValidator>();
	collection.AddTransient<SkipQueryValidator>();
	collection.AddTransient<OrderByQueryValidator>();
	var provider = collection.BuildServiceProvider();
	
	var routeBuilder = new RouteBuilder(Mock.Of<IApplicationBuilder>(x => x.ApplicationServices == provider));
	routeBuilder.EnableDependencyInjection();
	var modelBuilder = new ODataConventionModelBuilder(provider);
	modelBuilder.EntitySet<MyType>("MyType");
	var model = modelBuilder.GetEdmModel();
	
	var uri = new Uri("http://localhost/api/mytype/12345?$select=Id");
		
	var httpContext = new DefaultHttpContext{
		RequestServices = provider
	};
	HttpRequest req = new DefaultHttpRequest(httpContext)
	{
		Method = "GET",
		Host = new HostString(uri.Host, uri.Port),
		Path = uri.LocalPath,
		QueryString = new QueryString(uri.Query)
	};
	
	var context = new ODataQueryContext(model, typeof(MyType), new Microsoft.AspNet.OData.Routing.ODataPath());
	var options = new ODataQueryOptions<MyType>(context, req);
