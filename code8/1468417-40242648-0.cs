    int _ID = 2; // ID criteria
    List<object> result = new List<object>(); // we will use this to split parent at child, it is object type because we need Level
     var departments = entites.Departments.Where(x => x.ID == _ID).SelectMany(t => entites.Departments.Where(f => f.ID == t.DepartmentID),
                (child, parent) => new { departmentID = child.DepartmentID, Name = child.Name, ID = child.ID, level = 0,
                    Parent = new { DepartmentID = parent.DepartmentID, Name = parent.Name, ID = parent.ID, level = 1 }});
            // first we check our ID (we take A from where criteria), then with selectmany T represents the Department A, we need
            // department A's departmentID to find its parent, so another where criteria that checks ID == DepartmentID, so we got T and the new list 
            // basically child from first where parent from second where, and object created.
            // for showing the results
            foreach (var item in departments)
            {
                result.Add(new { DepartmentID = item.departmentID,ID = item.ID, level= item.level,Name = item.Name}); // child added to list
                result.Add(new { DepartmentID = item.Parent.DepartmentID, ID = item.Parent.ID, level = item.Parent.level, Name = item.Parent.Name }); // parent added to list
            }
