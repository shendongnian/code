    [HttpPost]
    public ActionResult MyFunction(var x) 
    {
     double z=Convert.ToDouble(x);
    
    
      return Json(new {success = true, JsonRequestBehavior.AllowGet});
    }
 
