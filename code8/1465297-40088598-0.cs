    public ActionResult Submit(Employee obj)
        {
            //
            if (ModelState.IsValid)
            {
                return View("Employee", obj);
            }
            else
            {
                return View("AddNewEmployee");
            }
        }
