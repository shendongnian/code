    [HttpPost]
    public ActionResult Index(IndexVm model)
    {
         var selected = model.EmployeeSelections.Where(a=>a.IsSelected).ToList();
        // If you want Id's select that
        var ids = selected.Select(g => g.Id);
        // to do : return something
    }
