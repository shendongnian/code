     public ActionResult Index(string searchby,string Search)
        {
            if (searchby == "Company")
            {
                return View(db.Customers.Where(x => x.Company.Contains == Search || Search == null).ToList());
            }
            else
            {
                return View(db.Customers.Where(x => x.LastName.StartsWith(Search)).ToList());
            }
        }
