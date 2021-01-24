    List<Employee> employees = new List<Employee>() { new Employee() { Name = "name1" },
                                                        new Employee() { Name = "name2" },
                                                        new Employee() { Name = "name3" } };
    Employee emp1 = employees.Where(x => x.Name == "name1").First();
    emp1.IsResponsiblePerson = true;
    Employee emp2 = employees.Where(x => x.Name == "name2").First();
    emp2.IsResponsiblePerson = true;
    foreach (Employee e in employees) 
    { 
         Console.WriteLine(e.IsResponsiblePerson); //false true false
    }
