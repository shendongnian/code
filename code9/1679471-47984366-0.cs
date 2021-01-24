    namespace TestSelectedItemInListView
    {
    	[ImplementPropertyChanged]
    	public class MyModel
    	{
    		public string Name { get; set; }
    		public string Surname { get; set; }
    
    		public bool Selected { get; set; }
    
    		public MyModel()
    		{
    		}
    	}
    }
