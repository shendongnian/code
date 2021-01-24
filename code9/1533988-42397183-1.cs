    [HttpGet]
        public JsonResult GetLocList()
        {
            //IEnumerable<LocationTbl> ie = (from d in db.LocationTbls
            //                              select d).ToList();
            var ret = db.LocationTbls.Select(x => new { x.Id, x.LocName }).ToList();
            return Json(ret,JsonRequestBehavior.AllowGet);
        }
