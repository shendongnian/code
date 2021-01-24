    public JsonResult GetStops()
    {
       using (var ctx = new GoogleMapTutorialEntities())
       {
          var lastItem = ctx.Loggings.LastOrDefault(x => x.Datatype == 2).AsEnumerable().Select(
          x => new
          {
             lng = x.Longitude2,
             lat = x.Latitude2,
             difference = (int)(x.LastStartDifference?.TotalMinutes ?? -1) * x.coeff
    
          });
    
          return Json(lastItem, JsonRequestBehavior.AllowGet);
      }
    }
