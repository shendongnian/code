      private static string RenderPartialViewToString(Controller controller, string viewName, Object model)
            {
                using (StringWriter sw = new StringWriter())
                {
                    ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(controller.ControllerContext, viewName);
                    controller.ViewData.Model = model; 
    
                    ViewContext viewContext = new ViewContext(controller.ControllerContext, viewResult.View, controller.ViewData, controller.TempData, sw);
                    viewResult.View.Render(viewContext, sw);
    
                    return sw.ToString();
                }
            }
