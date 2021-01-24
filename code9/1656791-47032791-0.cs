    private string RenderRazorViewToString(string viewName, object model, Dictionary<string, object> oDicParametresViewData = null, string sHtmlFieldPrefix = "")
        {
            ViewData.Model = model;
            if (oDicParametresViewData != null) foreach (var param in oDicParametresViewData) ViewData[param.Key] = param.Value;
            if (sHtmlFieldPrefix != "") ViewData.TemplateInfo = new System.Web.Mvc.TemplateInfo { HtmlFieldPrefix = sHtmlFieldPrefix };
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }
     Response.StatusCode = 666;
     return Json(new
            {
                Html = RenderRazorViewToString("view", model),            
            });
