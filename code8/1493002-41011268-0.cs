     public ActionResult AjaxPage(string sortOrder, string currentFilter, string searchString, string[] Name, string[] WorkerNo, string[] Group, string[] Department, string Status, string StartDate, string EndDate,string Flag,string Result)
            {
                if (Flag == "Query")
                {
                    if (Result != "")
                    {
                        List<WorkerViewModel> Deserialobj = (List<WorkerViewModel>)Newtonsoft.Json.JsonConvert.DeserializeObject(Result, typeof(List<WorkerViewModel>));
                        return PartialView("_PartialAjaxPage", Deserialobj);
                    }
    
           
    
                }
     ///////// remaining code 
}
