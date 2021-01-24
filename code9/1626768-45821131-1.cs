    public ActionResult Test()
    {
        try
        {
            _filmService.FindById(-1);
            return View();
        }
        catch (System.Exception)
        {
            _filmService.Exists(null);
            return View();
        }
    }
