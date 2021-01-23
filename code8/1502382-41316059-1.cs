     [HttpPost]
            public ActionResult Index(FormCollection collection)
            {
                var searchby = collection["searchBy"].ToString();
                if (searchBy == "Company")
                {
                    return View(db.Customers.Where(x => x.Company.Contains == Search || Search == null).ToList());
                }
                else
                {
                    return View(db.Customers.Where(x => x.LastName.StartsWith(Search)).ToList());
                }
                return View();
            } 
