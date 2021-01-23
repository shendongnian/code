    public class MyVmModel
    {
        public string TrainingProgramName { get; set;}
        public string ColorCode { get; set;}
        public string Response { get; set;}
    
    }
    [HttpPost]
    [Authorize(Roles = "Affiliate")]
    public ActionResult Save(MyVmModel myVm)
    {
        //your code here
        myVm.Response = "your message here"
        return Json(myVm);
    }
