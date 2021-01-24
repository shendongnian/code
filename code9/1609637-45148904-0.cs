        DALHelper dalHelp = new DALHelper();
        
        public ActionResult Index()
        {
            //Get a list of task types from the data access layer
            //Cast them into a SelectItemList and pass them into viewBag
            ViewBag.TaskDD = dalHelp.GetTaskTypes().Select(a => new SelectListItem { Text = a.Name, Value = a.TaskTypeID.ToString() }).ToList();
            return View();
        }
        public ActionResult AddSomething()
        {
            TimeEntry te = new TimeEntry();
            return View(te);
        }
        [HttpPost]
        public ActionResult AddSomething(TimeEntry te)
        {
            if (ModelState.IsValid)
            {
                //call my Data Access Layer to add new entry and redirect to wherver on success 
                if (dalHelp.CreateTimeEntry(te))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    //something happened during adding entry into DB, write whatever code to handle it gracefully
                    //I need to reload my viewbag since it has since been cleared (short lived)
                    ViewBag.TaskDD = dalHelp.GetTaskTypes().Select(a => new SelectListItem { Text = a.Name, Value = a.TaskTypeID.ToString() }).ToList();
                    ModelState.AddModelError("TimeEntryID", "An Error was encountered...");
                    return View(te);
                }
            }
            else
            {
                //I need to reload my viewbag since it has since been cleared (short lived)
                ViewBag.TaskDD = dalHelp.GetTaskTypes().Select(a => new SelectListItem { Text = a.Name, Value = a.TaskTypeID.ToString() }).ToList();
                return View(te);
            }
        }
