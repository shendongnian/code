    var values = new Person[]
    {
        new Person { Name = "Name1", Amount = 300 },
        new Person { Name = "Name2", Amount = 500 },
        new Person { Name = "Name3", Amount = 300 },
        new Person { Name = "Name4", Amount = 300 }
    };
    var subgroup = values.TakeWhileAdding(item => item.Amount, total => total < 1000);
    foreach (var v in subgroup)
        Trace.WriteLine(v);
