    public ActionResult SelectProjects(int id)
        {
            DemoViewModel model = new DemoViewModel()
            {
                // Your ViewModel
            };
            return PartialView("_ProjectDetails", model);
        }
