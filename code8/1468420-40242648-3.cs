    List<object> childParent = new List<object>();
    // basically get the child first
    Departments child1 = entites.Departments.Where(x => x.ID == _ID).FirstOrDefault();
    // find parent with child object
    Departments parent1 = entites.Departments.Where(x => x.ID == child1.DepartmentID).FirstOrDefault();
    // create child object with level
    childParent.Add(new { child1.DepartmentID, child1.ID,child1.Name , level = 0});
    // create parent object with level
    childParent.Add(new { parent1.DepartmentID,parent1.ID,parent1.Name, level = 1 });
