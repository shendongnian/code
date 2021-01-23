    public ActionResult Details(int id)
    {
        try 
        {
           var task = db.Tasks.Find(id);
        }
        catch(HttpException e) 
        {
           throw new HttpException(404, "Task not found.")
        }
    
        return View(task);
    }
    
    public PartialViewResult ShowTaskByID(int id)
    {
        try
        {
            var tasks = db.Tasks.Find(id).TaskName;    
        }
        catch(HttpException e) 
        {
           throw new HttpException(404, "Task nout found.")
        }
        
        return PartialView("_ShowTask", tasks);
    }
