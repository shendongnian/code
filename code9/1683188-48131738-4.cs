    var dict1 = new Dictionary<int, List<Employee>>();
    dict1.Add(1, emplist);
    dict1.Add(2, emplist1);
    List<Employee> ivalue = null;
    if (dict1.TryGetValue(1, out ivalue))
    {
        Console.WriteLine(ivalue); // this will print System.Collections.Generic.List<Employee>
        foreach (Employee emp in ivalue)
        {
            Console.WriteLine(emp.EID);
        }
    }
