    	public class AffData {
    		
    		public string Property1 { get; set; }
    	}
    
    	
    
    
    	public class AnotherObject1 {
    	
    		public string Property1 { get; set; }
    	}
    
    	
    	public class AnotherObject2 {
    	
    		public string Property1 { get; set; }
    	}
    
    
    	public class PersonData {
    	
    		public List<AffData> AffDataList { get; set; }
    		
    		public AnotherObject1 AnotherObject1 { get; set; }
    		
    		public AnotherObject2 AnotherObject2 { get; set; }
    	}
