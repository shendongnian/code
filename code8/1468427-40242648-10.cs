     List<Departments> childParent = new List<Departments>();
     // or basically get the child first
     Departments child1 = entites.Departments.Where(x => x.ID == 7).FirstOrDefault();
     // find parent with child object
     Departments parent1 = entites.Departments.Where(x => x.ID == child1.DepartmentID).FirstOrDefault();
     // create child object with level
     Departments dep = new Departments(); // I add to department class a string level field
     dep.DepartmentID = child1.DepartmentID;
     dep.ID = child1.ID;
     dep.Name = child1.Name;
     dep.level = 0; // first item
     childParent.Add(dep);
     // create parent object with level
     dep = new Departments();
     dep.DepartmentID = parent1.DepartmentID;
     dep.ID = parent1.ID;
     dep.Name = parent1.Name;
     dep.level = 1; // parent one
     childParent.Add(dep);
    
     while (childParent.Select(t => t.DepartmentID).Last() != null) // after added to list now we always check the last one if it's departmentID is null, if null we need to stop searching list for another parent
     {
           int? lastDepID = childParent.Last().DepartmentID; // get last departmentID 
           Departments tempDep = entites.Departments.Single(x => x.ID == lastDepID); // find as object
           tempDep.level = childParent.Last().level + 1; // increase last level
           childParent.Add(tempDep); // add to list          
     }
