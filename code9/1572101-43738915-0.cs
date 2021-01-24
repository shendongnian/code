    public ActionResult Details(int Id)
    {
       var viewmodel = _repo.GetSingle(Id);
        return View(viewmodel );
    }
