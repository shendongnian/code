    public async Task<JsonResult> Index()
    {
      string data = await _myService.GetList();
      return Json(new
            {
                JsonData = data ,
                Status = true
            }, JsonRequestBehavior.AllowGet);
    }
