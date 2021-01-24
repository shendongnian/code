    [HttpPost]
    public ActionResult TestPost([FromBody]string value)
    {
        var result = value;
        return Content("hello");
    }
