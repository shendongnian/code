    //Basic node
    public class Node
	{
	}
	
    //A node that can contain a T (which must be a BaseClass or derived from one)
	public class Node<T> : Node where T : BaseClass
	{
		public T Parent { get; set; }
		public T This { get; set; }
		
		public Node(T innerClass) 
		{
			this.This = innerClass;
			innerClass.ContainerNode = this;
		}
	}
	
