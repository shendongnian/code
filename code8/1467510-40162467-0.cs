    public JsonResult tt()
    {
         var xx = from n in db.Accessors
                  join cn in db.Countrys on n.CountryID equals cn.CountryID
                  select new
                  {
                     n.Name,
                     n.Id,n.CountryID,
                     cn.CountryName
                  };
        return Json(xx, JsonRequestBehavior.AllowGet };
    }
