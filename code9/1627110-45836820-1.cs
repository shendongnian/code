    [AllowAnonymous]
        public ActionResult Register()
        {
    ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "CustomerCompanyName");
                return View();
            }
