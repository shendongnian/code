    public class HistoryController : Controller
     {
        public ActionResult Index(/*put whatever parameters in here*/)
        {
            var html = GetEmailText(new Course { CourseName = "your coursename" });
            // send your email
            return View();
        }
        private string GetEmailText(Course course)
        {
            return RenderRazorViewToString("CourseEmailTemplate", course);
        }
        private string RenderRazorViewToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext,
                                                                         viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View,
                                             ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }
    }
