    public ActionResult Index(Presenter model, int? status, ...)
    {
        int pageNumber = (id ?? 1);
        if (ModelState.IsValid)
        {
        using(var connection = new Context())
        {
            if(status != null)
            {
              ViewBag.Status = status.value;
              model.Tasks = connection.Tasks
                                    .Where(task => task.Status == status.value)
                                    .ToPagedList(pageNumber, 30);
            }
            else
            {
               model.Tasks = connection.Tasks
                                      .ToPagedList(pageNumber, 30);
            }
          }
        }
       return View(model);
    }
