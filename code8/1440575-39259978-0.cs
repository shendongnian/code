    public class TestModel
    {
    public string applNo {get;set;}
    public int amount{get;set;}
    public DateTime schldDate{get;set;}
    public string userId{get;set;}
    public string tdcId{get;set;}
    }
    
       [HttpPost]
        public JsonResult PostScheduleMakeUpPayment(TestModel model)
        {
            //return _updateTdc.ProcessMakeUpPayment(model.applNo, model.amount, model.schldDate, model.userId, model.tdcId);
            return Json("Success:True");
        }
