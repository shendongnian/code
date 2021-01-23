    public override void OnActionExecuting(ActionExecutingContext context)
    {
       var path = context.HttpContext.Request.Path.Value.Trim().ToLower();
       var session = context.HttpContext.Session;
       var permittedUrls = session.GetJson<List<string>>(SesstionStateKeys.PermittedUrls);
    
       if (permittedUrls == null)
       {
          context.Result = new RedirectResult("your_url");
          return;
       }
    
       if (permittedUrls.Any(url => path.Contains(url.Trim().ToLower())))
       {
          return;
       }
    
       context.Result = new ForbidResult(); //new UnauthorizedResult();
    
       base.OnActionExecuting(context);
    }
