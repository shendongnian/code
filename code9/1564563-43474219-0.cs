    foreach (var item in items.Where(x => x.SomeCondition)
                              .Select((x, i) => new { item = x, index = i })
    {
        item.item.OneThing = item.index != 0;
        item.item.AnotherThing = true;
    }
    
