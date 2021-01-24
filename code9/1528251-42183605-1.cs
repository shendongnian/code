	class Edge<T> where T: IEquatable<T>
	{
		public T Node1 { get; }
		public T Node2 { get; }
		public string Name { get; }
		public Edge(string name, T node1, T node2)
		{
			Name = name;
			Node1 = node1;
			Node2 = node2;
		}
		public override string ToString() => Name;
	}
