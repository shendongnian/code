    var names = new List<Name> { new Name(list[0]) };
    for (var i = 1; i < list.Count; i++)
    {
        var name = list[i];
        var count = list.Take(i - 1).Where(n => n == name).Count() + 1;
        names.Add(new Name(count < 2 ? name : name + count.ToString()));
    }
