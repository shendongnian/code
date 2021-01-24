    using System;
    using System.Collections.Generic;
    using System.Xml;
    using System.Data;
    					
    public class DataObject
    {
    	public string Name { get; set; }
    }
    
    public class Program
    {
    	public static void Main()
    	{
    		Queue();
    	}
    	
    	public static void DataTable()
    	{
    		var dataTable = new DataTable();
    		dataTable.Columns.Add("Name", typeof(string));
    		
    		for (int nLoop = 0; nLoop < 10000; nLoop++)
    		{
    			var dataObject = new DataObject();
    			dataObject.Name = "Message number " + nLoop;
    			
    			dataTable.Rows.Add(dataObject);
    			
    			if (dataTable.Rows.Count > 1000)
    				dataTable.Rows.RemoveAt(0);
    		}	
    	}
    	
    	public static void Queue()
    	{
    		var queue = new Queue<DataObject>();
    		
    		for (int nLoop = 0; nLoop < 10000; nLoop++)
    		{
    			var dataObject = new DataObject();
    			dataObject.Name = "Message number " + nLoop;
    			
    			queue.Enqueue(dataObject);
    			
    			if (queue.Count > 1000)
    				queue.Dequeue();
    		}	
    	}
    }
