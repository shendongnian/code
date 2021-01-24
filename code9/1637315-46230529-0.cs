    public ActionResult Index()
    		{
            var model = "view model";
            // Pass view model as the second parameter
			return View("About", model);
    		}
    public ActionResult About()
    		{
    			ViewBag.Message = "Your application description page.";
                // Not need pass view name because view name and action method name are same (About
    			return View();
    		}
