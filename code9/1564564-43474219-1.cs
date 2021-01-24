    foreach (var item in items.Where(x => x.SomeCondition)
                              .Select((x, i) => new { item = x, index = i })
    {
        // If you have a lot to do:
        if (item.index != 0)
        {
            item.item.YetAnotherThing = 15;
            item.item.OneThing = true;
        }
        // If you have a simple boolean
        item.item.OneThing = item.index != 0;
        // Something that will always happen.
        item.item.AnotherThing = true;
    }
