    [HttpPost]
    public JsonResult GetAllCICO(string SSN)
    {
        var cicos = GetCICO(SSN).ToList();
        var jsonResult = Json(new{data = cicos});
        return jsonResult;
    }
