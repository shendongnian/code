    var list = new EmployeeCollection();
    list.Add(new Employee { Name = "1", IsResponsiblePerson = true });
    list.Add(new Employee { Name = "2", IsResponsiblePerson = false });
    list.Add(new Employee { Name = "3", IsResponsiblePerson = false });
    list.Add(new Employee { Name = "4", IsResponsiblePerson = false });
    list.Add(new Employee { Name = "5", IsResponsiblePerson = false });
    list.Last().IsResponsiblePerson = true;  // now the first employee's IsResponsiblePerson is set to false
