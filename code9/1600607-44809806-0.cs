    List<Tuple<int,int>> edges = new List<Tuple<int, int>>();
    for (int i = 1; i < vertices.Length - 1; i++)
    {
        for (int j = i + 1; j < vertices.Length; j++)
        {
            edges.Add(Tuple.Create(i, j));
        }
    }
