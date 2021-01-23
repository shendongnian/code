    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new CourseInfo
            {
                AvailableMajorNames = GetColorListItems()
            };
            return View(model);
        }
    
        [HttpPost]
        public ActionResult Index(CourseInfo model)
        {
            if (ModelState.IsValid)
            {
                var majorCode = model.SelectedMajorCode;
                return View("Success");
            }
            // If we got this far, something failed, redisplay form
            // ** IMPORTANT : Fill AvailableMajorNames again; 
            //    otherwise, DropDownList will be blank. **
            model.AvailableMajorNames = GetMajorListItems();
            return View(model);
        }
    
        private IList<SelectListItem> GetMajorListItems()
        {
            // This could be from database.
            return new List<SelectListItem>
            {
                new SelectListItem {Text = "One", Value = "1"},
                new SelectListItem {Text = "Two", Value = "2"}
            };
        }
    }
