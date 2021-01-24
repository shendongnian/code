    public ActionResult Index()
    {
        var list = db.TaskAssigneds.Select(l => new TasksAssignedViewModel
            {
                TaskModelId = l.TasksModel.Id,
                UserId = l.User.Id,
                TaskModelName = l.TasksModel.Name,
                UserName = l.User.Name
            });
        return View(list.ToList());
    }
