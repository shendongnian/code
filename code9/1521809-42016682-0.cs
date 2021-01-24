     Employees employees = new Employees(); 
        DataSourceSettings settings = new DataSourceSettings(); 
        settings.ParentId = "ParentId"; 
        settings.Id = "EmpId"; 
         
         
        employees.Add(new Employee() { EmpId = 1, ParentId = "", Name = "Charly", Designation = "Manager" }); 
        employees.Add(new Employee() { EmpId = 2, ParentId = "1", Name = "Ronald", Designation = "TeamLead" }); 
         
        settings.DataSource = employees; 
        sfdiagram.DataSourceSettings = settings; 
         
 
