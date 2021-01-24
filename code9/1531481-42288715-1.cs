	public class Node{
		public List<NodeProperty> Properties;
	}
	
	public class NodeProperty
	{
		public string Name;
		public string Type;
	}    
    var nodes = new List<Node>
	{
		new Node {
			Properties  = new List<NodeProperty>
			{
				new NodeProperty {Name = "node1", Type="string"},
				new NodeProperty {Name = "node2", Type="int"},
			}
		},
		new Node {
			Properties  = new List<NodeProperty>
			{
				new NodeProperty {Name = "node3", Type="string"},
				new NodeProperty {Name = "node4", Type="int"},
			}
		},
		
	};
	
