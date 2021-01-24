       public static string RenderView(this Controller controller, string viewName, object model, HttpContext currentContext)
        {
          return RenderView(controller, viewName, new ViewDataDictionary(model), currentContext);
        }
    
    
        public static string RenderView(this Controller controller, string viewName, ViewDataDictionary viewData, HttpContext currentContext)
        {
          var routeData = new RouteData();
          routeData.Values.Add("Controller", "ASPXTest");  //must match your Controller name
          routeData.Values.Add("Action", "Test");  //must match your Action name
    
          HttpContextWrapper wrapper = new HttpContextWrapper(currentContext);
          controller.ControllerContext = new ControllerContext(wrapper, routeData, controller);
          var viewResult = ViewEngines.Engines.FindView(controller.ControllerContext, viewName, null);
    
          StringWriter stringWriter;
          viewData = new ViewDataDictionary();
    
    
          using (stringWriter = new StringWriter())
          {
            var viewContext = new ViewContext(
                controller.ControllerContext,
                viewResult.View,
                viewData,
                controller.ControllerContext.Controller.TempData,
                stringWriter);
    
            viewResult.View.Render(viewContext, stringWriter);
            viewResult.ViewEngine.ReleaseView(controller.ControllerContext, viewResult.View);
          }
    
          return stringWriter.ToString();
        }
