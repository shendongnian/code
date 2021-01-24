    [HttpPost]
    public JsonResult ProcessExcelFile(HttpPostedFileBase file)
    {
    	// Process the excel... 
      var business = new BusinessLayer();
      var data = business.ValidateExcel(file);
    
      // Return the Json with the procced excel data.
      return Json(data, JsonRequestBehavior.AllowGet);
    }
