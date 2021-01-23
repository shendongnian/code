    using System;
    using System.Collections.Generic;
    
    public class Program
    {
    	public static void Main(string[] args)
    	{
    		BinSearchTree<int> myTree = new BinSearchTree<int>();
    		myTree.Insert(10);
    		myTree.Insert(15);
    		Console.WriteLine(myTree.ToString());
    	}
    }
    
    public class BinSearchTree<T> where T : IComparable<T>
    {
    	private List<T> values = new List<T>();
    	
        // rest of class omitted for clarity
    	public void Insert(T val) {
    		values.Add(val);
    	}
    	
    	public override string ToString() {
    		var result = string.Empty;
    		foreach(var v in values)
    		{
    			result += v + ", ";
    		}
    		
    		return result;
    	}
    }
