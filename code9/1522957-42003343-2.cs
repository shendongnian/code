    public ActionResult getRolesByYear(int year)
    {
        var list = list of RoleViewModel objects;
        if(Request.IsAjaxRequest())
        {
           return PartialView(list);
        }
        else
        {
          return View(list);
        }
    }
