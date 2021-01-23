    [HttpGet]
    public ActionResult Edit(int? _id)
    {
        if (_id==null)
        {
             return new HttpStatusCodeResult(HttpStatusCode.NoContent); 
        }
        else
        {
            return View();
        }
    }
