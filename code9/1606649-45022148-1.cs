    [HttpPost]
    public ActionResult Index(List<string> item)
    {
            if(item != null)
            {
                var json = new { success = true };
                return Json(json);
            }
            return Json(false);
     }
