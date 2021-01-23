    [HttpPost]
    public void SomeApi()
    {
       var test = HttpContext.Current.Request.Form["Test"];
    }
