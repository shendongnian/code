    var dict1 = new Dictionary<int, List<Employee>>();
    dict1.Add(1, emplist);
    dict1.Add(2, emplist1);
    if (dict1.ContainsKey(1))
    {
        var ivalue = dict1[1];
        Console.WriteLine(ivalue); // this will print System.Collections.Generic.List<Employee>
        foreach (Employee emp in ivalue)
        {
            Console.WriteLine(emp.EID);
        }
    }
