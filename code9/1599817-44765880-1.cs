    public ActionResult ActionForMyPartial()
    {
        if (Request.IsAjaxRequest())
        {
            return PartialView();           
        }
        return View();
    }
