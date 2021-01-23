    using System;
    using System.Collections.Generic;
    
    public class Program
    {
    	public static void Main()
    	{
    		List<DataCls> lstData = new List<DataCls>
            {
    			new DataCls {Message="M1", Priority=null, Key=null },
    			new DataCls {Message=null, Priority="P1", Key=null }
    		};
    
    		lstData.ForEach(a => { 
    			a.Key = a.Message == null ?
    				"NA" : 
    				a.Message + ":" + (a.Priority == null ? 
    					"NA" : 
    					a.Priority);
    		});
    		
    		foreach(var d in lstData)
    		{
    			Console.WriteLine(d.Key);
    		}
    	}
    }
    
    public class DataCls
    {
    	public string Message
    	{
    		get;
    		set;
    	}
    
    	public string Priority
    	{
    		get;
    		set;
    	}
    
    	public string Key
    	{
    		get;
    		set;
    	}
    }
