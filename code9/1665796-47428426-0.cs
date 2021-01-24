    public ActionResult SampleKendoCreate(KendoScheduleEventModel data)
    {
       return Json(data.models);
    }
 
    public class KendoScheduleEventModel
    {
       public list<KendoScheduleEvent> models { get; set; }
    }
