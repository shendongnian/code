    public ActionResult Index(int? id, int? status) // add any other parameters your filtering on
    {
        int pageNumber = (id ?? 1);
        var tasks = db.Tasks;
        if (status.HasValue)
        {
            tasks = tasks.Where(x => x.Status == status.Value)
        }
        if (otherParametersHaveValue)
        {
            tasks = tasks.Where(....);
        }
        Presenter model = new Presenter()
        {
            PageNumber = id ?? 1,
            Status = status,
            .... // set any other filter properties from the parameters
            Statuses = new SelectList(...),
            Tasks = tasks.ToPagedList(pageNumber, 30)
        };
        return View(model );
    }
