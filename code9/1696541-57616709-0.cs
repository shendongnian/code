	public void OnPageHandlerSelected(PageHandlerSelectedContext context) {
		var pageModel = context.HandlerInstance as PageModel ??
			throw new Exception("This page filter must run in a PageModel.");
		
		pageModel.ViewData["Member"] = memberUser;
		...
	}
