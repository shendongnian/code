    // static testdata - can be obtained from JSON for real code
    IEnumerable<Item> items = new Item[]
    {
        new Item{ Old = "a", Target = "b" },
        new Item{ Old = "b", Target = "c" },
        new Item{ Old = "c", Target = "d" },
        new Item{ Old = "d", Target = "a" },
        new Item{ Old = "j", Target = "x" },
        new Item{ Old = "w", Target = "s" },
    };
    var successors = items.ToDictionary(x => x.Old, x => x.Target);
    var visited = new HashSet<string>();
    List<List<string>> cycles = new List<List<string>>();
    foreach (var item in items)
    {
        string cycleStart = FindCycle(item.Old, successors, visited);
        if (cycleStart != null)
        {
            // cycle found, get detail information about involved nodes
            List<string> cycle = GetCycleMembers(cycleStart, successors);
            cycles.Add(cycle);
        }
    }
