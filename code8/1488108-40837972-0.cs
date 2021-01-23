    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace alistnamespace
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			List<int> my_list=new List<int>();
    			functionaddtolist(ref my_list);
    			for(int i=0;i<my_list.Count;i++)
    			{
    				Console.WriteLine("List item " + i.ToString() + "=" + my_list[i]);
    			}
    		}
    
    		static void functionaddtolist(ref List<int> mylist_ref)
    		{
    			mylist_ref.Add(42);				//Add one element
    
    		}
    	}
    }
