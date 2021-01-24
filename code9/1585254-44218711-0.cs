    public class MyQueue<T, S> where T : MyLinkNode<S>
    {
    	private T Head;
    	private T Last;
    	public MyQueue() {  }
    	public void Enqueue(T item)
    	{
    		item.Prev = Last;
    		Last.Next = item;
    		Last = item;
    	}
    }
    public void BFS(GraphNode v)
    {
    	MyQueue<GraphNode, string> queue = new MyQueue<GraphNode, string>(); 
    }
