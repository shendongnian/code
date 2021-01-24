    public ActionResult AddTraining(EmployeeSkillVM model)
    {
        foreach(var employee in model.Employees)
        {
            // Get the ID's of the selected skills
            var selected = employee.Skills.Where(x => x.IsSelected).Select(x => x.ID);
            ....
