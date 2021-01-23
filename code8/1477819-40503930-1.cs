    public class ListCode : List<int>
    {
        public ListCode(string code)
    	{
    		this.Code = code;
    	}
        public string Code { get; set; }
    }  
 
    ...
    ListCode myList = new ListCode("bar") { 1, 2, 3 };
    
    
