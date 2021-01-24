    [HttpPost]
    public ActionResult Create(Employee model)
    {
      // here we we get the all values given from the view ...
      string example = model.Name;
      List<Tarea> list = model.Tareas; // and iterate through model.Tareas to get List model values
    }
