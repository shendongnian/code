    public ActionResult NewUser()
    {
         Session["newClient"] = null;
         return View("Index",_vm);
    }
