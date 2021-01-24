    using System;
    using System.Data;
    					
    public class Program
    {
    	public static void Main()
    	{
    		DataTable table = null;
    		
    		Test(table);
    		
    		table = new DataTable();
    		
    		Test(table);
    	}
    	
    	public static void Test(DataTable table)
    	{
    		if(table == null)
    		{
    			Console.WriteLine("table is null");
    			return;
    		}
    		
    		if(table.IsInitialized == false)
    		{
    			Console.WriteLine("table is not initalised.");
    			return;
    		}
    		
    		Console.WriteLine("table row count: " + table.Rows.Count);
    	}
    }
