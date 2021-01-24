    public ViewResult AddTraining(int drillId)
    {
		// Get the skills (YFFCompetencys)
        var skills = from s in db.YFFCompetencys.Where(...).OrderBy(...);
		// Get the employees (YoungFFs)
        var employees = db.YoungFFs.Where(...).OrderBy(...)
        // Initialize view model
        EmployeeSkillVM model = new EmployeeSkillVM()
        {
            ID = drillId,
            ....
            Employees = employees.Select(x => new EmployeeVM()
            {
                ID = x.ID,
                Name = x.Name,
                Skills = skills.Select(y => new SkillVM()
                {
                    ID = y.ID
                }).ToList()
            }).ToList(),
            SkillList = skills.Select(x => x.Name)
        };
        // If editing existing data, then set the `IsSelected` property of SkillVM as required
        return View(model);
    }
