        var Combi = new[] { "W", "A", "S", "D" };
        var buffer = keys.Take(4).Buffer(4);
        var combiFound = keys.SelectMany(buffer)
              .Where(list => list.SequenceEqual(Combi));
        buffer.Subscribe(CombiHappend(), Debug.LogException).AddTo(this);
        combiFound.Subscribe(CombiHappend(), Debug.LogException).AddTo(this);
    }
    private static System.Action<IList<string>> CombiHappend()
    {
        return (items) => { Debug.LogWarning("Combi Happened!" + string.Join(",", items.ToArray())); };
    }
