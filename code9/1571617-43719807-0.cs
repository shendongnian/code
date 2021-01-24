    [HttpPost]
    public ActionResult Index(MyViewModel model)
    {
        if (model.IsUserExists)
        {
            if (ModelState.IsValid)
            {
               ...
            }
            else
            {
                ...
            }
        }
    }
