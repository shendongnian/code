	public class Node
	{
		public T GetParent<T>() where T : BaseClass
		{
			return ((Node<T>)this).Parent;
		}
		
		static public Node<T> Create<T>(T innerClass) where T : BaseClass
		{
			return new Node<T>(innerClass);
		}
		
		static public T GetParent<T>(T child) where T: BaseClass
		{
			return child.NodeContainer.GetParent<T>();
		}
	}
