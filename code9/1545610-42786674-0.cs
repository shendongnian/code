     Public  ActionResult Button(int Id)
        {
        MasterM model = new MasterM();
        model.Id = Id;
         if (!ModelState.IsValid)
                    {
                        return View(model);
                    }
                    return View(model);
        }
