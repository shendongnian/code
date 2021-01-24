    [HttpGet]
    public JsonResult GetObjects(string someVar)
    {
        var response = BaseResponse<InspectionModel>();
        try {
            response.Data = GetObjects(someVar);
        }
        catch(Exception e) {
            response.Error = e;
        }
        return Json(response.GetResponse() , JsonRequestBehavior.AllowGet);
    }
