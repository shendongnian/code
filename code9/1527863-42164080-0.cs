    namespace X.WebApp.Models {
    
    	public class A {
    		public int A1 { get; set; }
        		public DateTime A2 { get; set; }
        		public List<B> A3 { get; set; }
    	}
    
    	public class B {
    		public string B1 { get; set; }
        		public string B2 { get; set; }
        		public string B3 { get; set; }
    	}
    }
    namespace X.WebApi.Models {
    
    	public class A {
    		public int A1 { get; set; }
        		public List<B> A3 { get; set; }
    	}
    
    	public class B {
    		public string B1 { get; set; }
    	}
    }
