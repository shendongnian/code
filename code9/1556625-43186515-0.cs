    // Type parameters of Tuple<,,> depend on the types of Prop1..Prop3
    var expect = new HashSet<Tuple<string,string,string>>(
        targetList.Select(item => Tuple.Create(item.Prop1, item.Prop2, item.Prop3))
    );
    var matches = sourceList
        .Where(item => expect.Contains(Tuple.Create(item.Prop1, item.Prop2, item.Prop3)))
        .ToList();
