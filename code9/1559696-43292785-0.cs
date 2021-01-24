    var controller = new MyAwesomePdfController();
	var httpRequest = new HttpRequest("", "http://mySomething", "");
	var stringWriter = new StringWriter();
	var httpResponse = new HttpResponse(stringWriter);
	var routeData = new RouteData();
	routeData.Values.Add("Controller", "MyAwesomePdf");  //must match your Controller name
	routeData.Values.Add("Action", "Receipt");  //must match your Action name
	
	var httpContextMock = new HttpContext(httpRequest, httpResponse)
	{
        //this is probably irrelevant to you, can set user principal here
		//User = new GenericPrincipal(
		//	new GenericIdentity(username),
		//	userRoles //new string[0]
		//)
	};
	controller.ControllerContext = new ControllerContext(new HttpContextWrapper(httpContextMock), routeData, controller);
    var receiptId = 1234;
	var pdfResult = await controller.Receipt(receiptId) as ViewAsPdf;  //should return a pdf file
