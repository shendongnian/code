    public class HistoryController : Controller
     {
        public ActionResult Index(/*put whatever parameters in here*/)
        {
           // Fetch your model 
           // just example data
           var course = new Course { CourseName = "your coursename" };
            
           var html = GetEmailText();
            // send your email
            return View(); // or redirect to action
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
