    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Newtonsoft.Json;
    
    
    public class Program
    {
    	public static void Main()
    	{
    		string input = @"[ 
    			 {'file': 'fileName1', 'key':0, title:'u1'},
    			 {'file': 'fileName1', 'key':2, title:'u1'},
    			 {'file': 'fileName2', 'key':5, title:'u1'},
    			 {'file': 'fileName2', 'key':10, title:'u1'}
    		]";
    		
    		var existingList = JsonConvert.DeserializeObject<List<CurrentType>>(input);
    			
    		var dictionary = new Dictionary<string,List<RequiredTypeFile>>();
    		
    		
    		var distinctFileNames =  existingList.Select(x=> x.File).Distinct().ToList();
    		
    		distinctFileNames.ForEach(x=>
    								  {
    									  var fileValue = existingList.Where(m=>m.File==x)
    										.Select(m => new RequiredTypeFile
    												{
    													Key = m.Key,
    													Title = m.Title
    												}).ToList();
    									  dictionary.Add(x,fileValue);
    								  });
    		
    		var reqdJson = JsonConvert.SerializeObject(dictionary);
    		
    		
    		Console.WriteLine(reqdJson);
    	}
    }
    
    public class CurrentType
    {
    	public string File
    	{
    		get;
    		set;
    	}
    
    	public int Key
    	{
    		get;
    		set;
    	}
    
    	public string Title
    	{
    		get;
    		set;
    	}
    }
    
    public class RequiredTypeFile
    {
    	public int Key
    	{
    		get;
    		set;
    	}
    
    	public string Title
    	{
    		get;
    		set;
    	}
}
