    public ActionResult Test()
    {
        try
        {
            _filmService.FindById(-1);
        }
        catch (System.Exception)
        {
            _filmService.Exists(null);
        }
        return View();
    }
