    public class customJsonResult : JsonResult
    {
      //max control over serialization
     }
    //in the base controller override the Controller.Json helper method:
    protected internal override JsonResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
    {
        return new customJsonResult {
            Data = data,
            ContentType = contentType,
            ContentEncoding = contentEncoding,
            JsonRequestBehavior = behavior
        };
    }
