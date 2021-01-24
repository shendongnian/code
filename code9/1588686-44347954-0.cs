    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Program
    {
    	public static void Main()
    	{
    		var receivedList = new List<string>();
    		var AuthorFacets = new List<string>();
    		
    		receivedList.Add("2");
    		receivedList.Add("4");
    		receivedList.Add("6");
    
    		AuthorFacets.Add("1");
    		AuthorFacets.Add("2");
    		AuthorFacets.Add("3");
    		
    		
    		if (receivedList.Count < AuthorFacets.Count)
    		{
    			AuthorFacets = AuthorFacets.Where(i => receivedList.Contains(i)).ToList();
    		}
    		else
    		{
    			AuthorFacets.AddRange(receivedList.Where(i => !AuthorFacets.Contains(i)));
    		}
    		
    		Console.WriteLine(string.Join("\n",AuthorFacets));
    	}
    }
