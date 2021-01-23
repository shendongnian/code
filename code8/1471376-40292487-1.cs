        [HttpPost]
        public ActionResult YourAction(Employee emp)
        {
            if (ModelState.IsValid)
            {
                // do smth.
            }
            return View("Name Of the view");
        }
