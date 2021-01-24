    public JsonResult SerialNumberSearch(string serialnum)
    {
        var result = db.IASerialNoMasters
                       .SingleOrDefault(x => x.SerialNo == serialnum);;
        if(result == null)
        {
             // Do something if it doesn't exist
             return HttpNotFound();
        }
        return Json(result, JsonRequestBehavior.AllowGet);
    }
                    
