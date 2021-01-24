    public ActionResult ReturnCity(int provinceId)
    {
       _db.Configuration.ProxyCreationEnabled = false;
       var data = _db.Cities.Where(x => x.ProvinceId == provinceId);
       return Json(data , JsonRequestBehavior.AllowGet);
    }
