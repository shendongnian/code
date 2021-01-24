        public ActionResult Create()
        {
            NewUser nu = new NewUser();
            nu.CreatedBy = User.Identity.Name;
            ViewBag.DepartmentId = new SelectList(db.departments, "DepartmentId", "DepartmentName");
            ViewBag.LocationId = new SelectList(db.locations, "LocationId", "LocationName");
            return View(nu);
        }
