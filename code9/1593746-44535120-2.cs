    class Program
    {
    	static int Main(string[] args)
    	{
    
    		var obj = new Demo();
    		var t = Enumerable.Range(1, 500)
    		.Select((x, index) => Task.Run<int>(() => index %2 == 0 
    											? obj.UpdateList(new List<object>() { new { status = true } }) 
    											: obj.GetTotalCount())).ToArray();
    		Task.WaitAll(t);
    		Console.Write(obj.GetTotalCount());
    		Console.ReadLine();
    		return 1;
    	}
       
    	public class Demo
    	{
    		private List<Object> m_globalCopyOfList { get; set; }
    		public Demo() {
    			m_globalCopyOfList = new List<object>();
    		}
    		public int UpdateList(List<Object> newList)
    		{
    			//only read operation on global list, adding  items only to local list  
    			newList.AddRange(m_globalCopyOfList);
    			//reference assignment is atomic
    			m_globalCopyOfList = newList;
    			return 1;
    		}
    
    		public int GetTotalCount()
    		{
    			//reference assignment is atomic
    			var localCopyOfList = m_globalCopyOfList;
    			//if UpdateList method is called anytime during below operation, 
    			//m_globalCopyOfList ref will point to new list, localCopyOfList will not 
    			//be touched.
    			Console.WriteLine("Current count " + localCopyOfList.Count); 
    			return localCopyOfList.Count;
    		}
    	}
    }
    
