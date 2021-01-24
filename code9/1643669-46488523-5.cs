    /// <summary>
    /// Returns the list of nodes that are involved in a cycle
    /// </summary>
    /// <param name="cycleStart">This is required to belong to a cycle, otherwise an exception will be thrown</param>
    /// <param name="successors"></param>
    /// <returns></returns>
    private static List<string> GetCycleMembers(string cycleStart, Dictionary<string, string> successors)
    {
        var visited = new HashSet<string>();
        var members = new List<string>();
        var current = cycleStart;
        while (!visited.Contains(current))
        {
            members.Add(current);
            visited.Add(current);
            current = successors[current];
        }
        return members;
    }
