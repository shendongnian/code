    public ActionResult SampleKendoCreate(KendoRequest request)
    {
       var model = JsonConvert.DeserializeObject<KendoRequest>(request.models);
       return Json(data.models);
    }
 
    public class KendoRequest
    {
       public string models { get; set; }
    }
