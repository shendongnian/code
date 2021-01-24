    public HashSet<T> BFS<T>(Graph<T> graph, T start, int maxSteps, Action<T> preVisit = null)
    {    
    var visited = new HashSet<T>();
    if (!graph.AdjacencyList.ContainsKey(start))
        return visited;
    int stepsTaken = 0;
    var queue = new Queue<T>();
    queue.Enqueue(start);
    while (queue.Count > 0 && stepsTaken < maxSteps)
    {
        var vertex = queue.Dequeue();
        if (visited.Contains(vertex))
            continue;
        if (preVisit != null)
            preVisit(vertex);
        visited.Add(vertex);
        foreach (var neighbor in graph.AdjacencyList[vertex])
        {
            stepsTaken++;
            if (!visited.Contains(neighbor) && stepsTaken < maxSteps)
                queue.Enqueue(neighbor);
        }
    return visited;
    }
