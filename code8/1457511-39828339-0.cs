    var list = new List<MyClass>();
    list.Add(new MyClass { Name = "V" });
    list.Add(new MyClass { Name = "B" });
    list.Add(new MyClass { Name = "A" });
    list.Add(new MyClass { Name = "C" });
    //Create expression here,
    Func<MyClass,string> expression = s=>s.Name;
    var ordered = list.OrderByDescending(expression).ToList();
