            [HttpGet]
        [OutputCache(Duration = 86400, Location = OutputCacheLocation.ServerAndClient, VaryByParam = "none")]
        public JsonResult GetJson()
        {
            return Json(new{message = "Record created successfully!!!"},JsonRequestBehavior.AllowGet);
        }
