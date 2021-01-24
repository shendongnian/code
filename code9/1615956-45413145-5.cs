        var things = new List<Thing>
        {
            new Thing { Item1 = "Foo", Item2 = 0 },
            new Thing { Item1 = "Bar", Item2 = 1 },
            new Thing { Item1 = "Bla", Item2 = 2 },
        };
        var answerByItem1 = things.MatchBy(thing => thing.Item1, new[] { "Foo", "Bar" }).FurtherProcessing();
        var answerByItem2 = things.MatchBy(thing => thing.Item2, new[] { 1 }).FurtherProcessing();
