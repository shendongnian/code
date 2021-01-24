    public ActionResult Method()
    {
        return ChildActionMethod();
    }
    public ActionResult ChildActionMethod()
    {
        return RedirectToAction("SomeAction");
    }
