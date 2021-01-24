    class Graph<V> : IGraph<V, IEdge<V>> where V : IVertex
    {
        public IList<V> Vertices { get; } = new List<V>();
        public IList<IEdge<V>> Edges { get; } = new List<IEdge<V>>();
    }
