    public ViewResult List(string id)
        {
            var r = new Result
            {
                Controller = nameof(HomeController),
                Action = nameof(List),
            };
    
            ViewData["id"] = id ?? "<no value>";
            ViewData["catchall"] = RouteData.Values["catchall"];
    
            return View("Result", r);
        }
