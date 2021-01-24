    var list = (new[] {
        new {Prop1 = 45, Prop2 = "foo", Prop3 = 4.5}
    ,   new {Prop1 = 14, Prop2 = "bar", Prop3 = 3.1}
    }).ToList();
    ...
    var filtered = list.Where(x => x.Prop1==45).ToList();
