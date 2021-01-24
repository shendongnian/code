     [HttpPost]
        public ActionResult Create(tbl_employee listdisease)
        {
            try
            {
                // TODO: Add insert logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
