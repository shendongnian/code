    namespace DtoClassLib
    {
    	[DataContract]
    	public class Sales
    	{
    		[DataMember]
    		public string Name { get; set; }
    	}
    
    	[DataContract]
    	public class Client
    	{
    		[DataMember]
    		public string status { get; set; }
    
    		[DataMember]
    		public string message { get; set; }
    
    		[DataMember]
    		public List<Sales> listSales { get; set; }
    
    		public Client()
    		{
    			listSales = new List<Sales>();
    		}
    	}
    }
