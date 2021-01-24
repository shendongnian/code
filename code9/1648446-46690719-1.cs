        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }
        // POST: Customer/Create
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View(customer);
            }
            //do work
            return RedirectToAction("Index");
        }
