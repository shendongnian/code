        public void OnActionExecuting(ActionExecutedContext context)
        {
            var model = _mainDbContext.Groups.ToList();
           
            var result = context.Result as ViewResult;
            if (result != null)
            {
                context.Result = new ViewResult { ViewName = "Index", ViewData = new ViewDataDictionary(result.ViewData)
                {
                    Model = model
                }};
            }
        }
