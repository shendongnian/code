    /// <summary>
    /// Returns a node that is part of a cycle or null if no cycle is found
    /// </summary>
    static string FindCycleHelper(string start, Dictionary<string, string> successors, HashSet<string> stackVisited)
    {
        string current = start;
        while (current != null)
        {
            if (stackVisited.Contains(current))
            {
                // this node is part of a cycle
                return current;
            }
            stackVisited.Add(current);
            successors.TryGetValue(current, out current);
        }
        return null;
    }
