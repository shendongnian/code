    foreach (Employee f in emp)
    {
        // Create a new instance for each item.
        em = new EmployeeViewModel();
        em.EmployeeID = f.EmployeeID;
        em.FullName = f.FirstName + " " + f.LastName;
        em.Salary = f.Salary.ToString("C");
        if (f.Salary > 100)
        {
            em.salcolor = "green";
        }
        else
        {
            em.salcolor = "red";
        }
        emVM.Add(em);
    }
