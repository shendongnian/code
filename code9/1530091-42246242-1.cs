    [HttpPost]
    public ActionResult MyFunction(string x) 
    {
     double z=Convert.ToDouble(x);
    
    
      return Json(new {success = true, JsonRequestBehavior.AllowGet});
    }
 
