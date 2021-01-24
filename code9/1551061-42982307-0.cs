    [HttpGet]
    public virtual ActionResult CheckFollow()
    {
        var pass = false;
        return Json(new {result = pass}, JsonRequestBehavior.AllowGet);
    }
