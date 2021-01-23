    public ActionResult Index(Exception exception)
    {
        ErrorViewModel model;
        var statusCode = HttpStatusCode.InternalServerError;
        if (exception is HttpException)
        {
            statusCode = (HttpStatusCode)(exception as HttpException).GetHttpCode();
            
            // More details on this below
            if (exception is DisplayableException)
            {
                model = CreateErrorModel(exception as DisplayableException);
            }
            else
            {
                model = CreateErrorModel(statusCode);
                model.Exception = exception;
            }
        }
        else
        {
            model = new ErrorViewModel { Exception = exception };
        }
        return ErrorResult(model, statusCode);
    }
    public ActionResult Display([Bind(Prefix = "id")] HttpStatusCode statusCode)
    {
        var model = CreateErrorModel(statusCode);
        return ErrorResult(model, statusCode);
    }
    private ErrorViewModel CreateErrorModel(HttpStatusCode statusCode)
    {
        var model = new ErrorViewModel();
        switch (statusCode)
        {
            case HttpStatusCode.NotFound:
                // Again, this is only relevant to my business logic.
                // You can do whatever you want here
                model.ContentResourceKey = "error-page-404";
                break;
            case HttpStatusCode.Forbidden:
                model.Title = "Unauthorised.";
                model.Text = "Your are not authorised to access this resource.";
                break;
            // etc...
        }
        return model;
    }
    private ErrorViewModel CreateErrorModel(DisplayableException exception)
    {
        return new ErrorViewModel
        {
            Title = exception.DisplayTitle,
            Text = exception.DisplayDescription,
            Exception = exception.InnerException
        };
    }
    private ActionResult ErrorResult(ErrorViewModel model, HttpStatusCode statusCode)
    {
        HttpContext.Response.Clear();
        HttpContext.Response.StatusCode = (int)statusCode;
        HttpContext.Response.TrySkipIisCustomErrors = true;
        return View("Index", model);
    }
