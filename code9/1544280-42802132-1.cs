    	[DataContract]
    	public class CenterWebUser
    	{
    		[DataMember]
    		public string Name { get; set; }
    
    		[DataMember]
    		public string Email { get; set; }
    
    		//	Other fields for the user
    	}
    
    	public class SomeService : ISomeService
    	{
    		public CenterWebUser GetCenterWebUser()
    		{
    			DataSet ds = ...;
    
    			var userTable = ds.Tables["Users"];
    			var userRow = userTable.Rows[0];
    
    			return new CenterWebUser()
    			{
    				Name = userRow.Field<string>("Name"),
    				Email = userRow.Field<string>("Email")
    				// ...
    			};
    		}
    	}
    }
