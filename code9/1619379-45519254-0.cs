        public class YourClass
    	{
    		public int ClassIntProperty { get; set; }
    		public string ClassStringProperty { get; set; }
    	}
    	List<YourClass> YourClassItemsList = new List<YourClass>();
    	public void SeekItem()
    	{
    		//Get several items
    		var t = YourClassItemsList.Where(item => item.ClassIntProperty == 0).AsEnumerable();
    		var tt = YourClassItemsList.Where(item => item.ClassStringProperty == "abc").AsEnumerable();
    
    		//Get one item
    		var ttt = YourClassItemsList.FirstOrDefault(item => item.ClassIntProperty == 0);
    	}
