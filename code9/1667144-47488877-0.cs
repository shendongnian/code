    using System;
    using System.Data;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var ICol = GenerateColor(2, 3, 4, 5);
    		byte[] IColByte = new byte[4]{
    			(byte)ICol.Rows[0]["B"], 
    			(byte)ICol.Rows[0]["G"], 
    			(byte)ICol.Rows[0]["R"], 
    			(byte)ICol.Rows[0]["A"]};
    		Console.WriteLine(String.Join(", ", IColByte));  // Writes "2, 3, 4, 5"
    	}
    	
    	public static System.Data.DataTable GenerateColor(byte B, byte G, byte R, byte A)
    	{
    		System.Data.DataTable dt = new System.Data.DataTable();
    		dt.Columns.Add(new System.Data.DataColumn("B", typeof(byte)));
    		dt.Columns.Add(new System.Data.DataColumn("G", typeof(byte)));
    		dt.Columns.Add(new System.Data.DataColumn("R", typeof(byte)));
    		dt.Columns.Add(new System.Data.DataColumn("A", typeof(byte)));
    	
    		dt.Rows.Add(dt.NewRow());
    		dt.Rows[0]["B"] = B;
    		dt.Rows[0]["G"] = G;
    		dt.Rows[0]["R"] = R;
    		dt.Rows[0]["A"] = A;
    	
    		return dt;
    	}
    }
