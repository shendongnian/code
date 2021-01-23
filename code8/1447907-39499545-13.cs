    public PartialViewResult ShowTaskByID()
    {
        try
        {
            var tasks = db.Tasks.ToList();
        }
        catch(HttpException e) 
        {
           throw new HttpException(404, "Task nout found.")
        }
        
        return PartialView("_ShowTask", tasks);
    }
