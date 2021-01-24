    [HttpPost]
    public ActionResult MyFunction(string x) 
    {
     double z=Convert.ToDouble(x.Trim()); // trim just in case....
    
    
      return Json(new {success = true, JsonRequestBehavior.AllowGet});
    }
 
