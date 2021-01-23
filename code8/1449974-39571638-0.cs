     var result = dt1.AsEnumerable().Except(dt2.AsEnumerable(), new  DataRowComparer()).CopyToDataTable();
    public class DataRowComparer : IEqualityComparer<DataRow>
    {
    	/// <summary>
    	/// Whether the two strings are equal
    	/// </summary>
    	public bool Equals(DataRow x, DataRow y)
    	{
    		return x["PrimaryKey"] == y["PrimaryKey"];
    	}
    
    	/// <summary>
    	/// Return the hash code for this string.
    	/// </summary>
    	public int GetHashCode(DataRow dataRow)
        {
    		return dataRow["PrimaryKey"].GetHashCode();	
        	
    	}
    }
