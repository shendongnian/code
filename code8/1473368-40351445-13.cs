    class LinkListGen<T> where T : IComparable
	{
	    private LinkGen<T> list;
	    public LinkListGen() {  }
		
		private LinkGen<T> LastNode ()
		{
		    var temp = list;
		    while (temp != null && temp.Next != null)
		        temp = temp.Next;
		    return temp;
		} 
	
		public void AppendItem(T item)
		{
		    if (list == null)
		        list = new LinkGen<T>(item, null);
		    else
		    {
			    LinkGen<T> temp = LastNode();
		        temp.Next = new LinkGen<T>(item, null);
		    }
		}
		
		public void Concat(LinkListGen<T> list2)
		{
		    if (list2 == null)
			    return;
		    LinkGen<T> temp = list2.list;
		    while (temp != null)
		    {
		        AppendItem(temp.Data);
		        temp = temp.Next;
		    }
		}
		
		public void Copy(LinkListGen<T> list2)
		{
		    list = null;
			Concat(list2);
		}
		
	    class LinkGen<T2>
		{
		    public LinkGen(T2 item): this(item, null) { }
		    public LinkGen(T2 item, LinkGen<T2> list)
		    {
		        Data = item;
		        Next = list;
		    }
			
		    public LinkGen<T2> Next { set;  get; }
		    public T2 Data { set ; get ; }
		}
	}
