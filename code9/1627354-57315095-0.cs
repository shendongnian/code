    public class SqlGeographyResult
    	{
    		private byte[] bytes { get; }
    
    		public SqlGeographyResult(SqlGeography geography)
    		{
    			bytes = geography.Serialize().Value;
    		}
    
    		public SqlGeography ToGeography()
    		{
    			return SqlGeography.Deserialize(new System.Data.SqlTypes.SqlBytes(bytes));
    		}
    	}
