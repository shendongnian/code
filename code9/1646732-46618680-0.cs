    var viewContext = new ViewContext(actionContext,
        viewResult.View,
        viewDictionary,
        new TempDataDictionary(actionContext.HttpContext, _tempDataProvider),
        sw,
        new HtmlHelperOptions()
    );
    await viewResult.View.RenderAsync(viewContext);
    return sw.ToString();
