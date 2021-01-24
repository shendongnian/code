    [System.Web.Http.HttpPost]
    public JsonResult Push(JsonDynamicWrapper data)
    {
        try
        {
            var test = data.payload.ApplicationName;
        }
        catch(Exception ex)
        {
        }
        return Json(null);
    }
