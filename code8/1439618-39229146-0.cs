        protected string RenderPartialViewToString(string viewName, object model)
        {
             if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.RouteData.GetRequiredString("action");
            
            ViewData.Model = model;
    
            using (StringWriter sw = new StringWriter())
            {
                ViewEngineResult viewResult =     ViewEngines.Engines
                .FindPartialView(ControllerContext, viewName);
            ViewContext viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
    
            viewResult.View.Render(viewContext, sw);
    
            return sw.GetStringBuilder().ToString();
            }
        }
