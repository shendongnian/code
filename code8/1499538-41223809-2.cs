    public class MyVmModel
    {
        public string TrainingProgramName { get; set;}
        public string ColorCode { get; set;}
        public string Status { get; set;}
    
    }
    [HttpPost]
    [Authorize(Roles = "Affiliate")]
    public ActionResult Save(MyVmModel myVm)
    {
        //your code here
        myVm.Status= "your message here"
        return Json(myVm);
    }
