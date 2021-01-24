    var depts = new List<Department>
    {
        new Department { Name = "Accounting" },
        new Department { Name = "IT" },
        new Department { Name = "Marketing" }
    };
    var persons = new List<Person>
    {
        new Person { DeptName = "Accounting", Name = "Bob" }
    };
    var selection2 =
        from d in depts
        join p in persons on d.Name equals p.DeptName into joined2
        // See here DefaultIfEmpty can be passed a Person
        from j2 in joined2.DefaultIfEmpty(new Person { DeptName = "Unknown", Name = "Alien" })
        select j2;
    foreach(var thisJ in selection2)
	{
		Console.WriteLine("Dept: {0}, Name: {1}", thisJ.DeptName, thisJ.Name);
	}
