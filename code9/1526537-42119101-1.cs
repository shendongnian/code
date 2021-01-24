    using System;
    using System.Data;
    using System.Xml;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var dt = new DataTable { Columns = { "Name", "Role", "Comm w1", "Comm w2",  "Total Comm"}};
    		
    		
    		foreach(DataColumn column in dt.Columns){
    			if(column.ColumnName.Contains("Comm")){
    				Console.WriteLine(column.Ordinal.ToString());
    			}
    		}
    	}
    }
    // Output:
    // 2
    // 3
    // 4
