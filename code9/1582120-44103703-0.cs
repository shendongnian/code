     public ActionResult Balance()
        {
            People p = new People();
            p.Balance();
            return View(p);  //passing the model object
        }
