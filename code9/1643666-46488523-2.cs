    static string FindCycle(string start, Dictionary<string, string> successors, HashSet<string> globalVisited)
    {
        HashSet<string> stackVisited = new HashSet<string>();
        var result = FindCycleHelper(start, successors, stackVisited, globalVisited);
        // update collection of previously processed nodes
        globalVisited.UnionWith(stackVisited);
        return result;
    }
