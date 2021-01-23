        // GET: /Home/
        public ActionResult Index(string searchBy, string search)
        {
            ViewBag.SearchBy = searchBy;
            ViewBag.Search = search;
            if (searchBy == "Gender")
            {
                return View(db.tblEmployees.Where(x => x.Gender == search || search == null).ToList());
            }
            else
            {
                return View(db.tblEmployees.Where(x => x.Name.StartsWith(search) || search == null).ToList());
            }
        }
