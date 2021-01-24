    public ActionResult asdf()
    {
     . . .
        return RedirectToAction("AnotherAction");
        OR
   
        return Redirect("/ControllerName/ActionName?QueryParameter=Value");
    }
