    namespace WindowsFormsApp
    {
        class Car
        {
    		public Id Id { get; set; }
    		public Tires Tires { get; set; }
    	}
    	
    	public class Id
    	{
    		public string brand { get; set; }
    		public string model { get; set; }
    		public int year { get; set; }
    		public string r_no { get; set; }
    		public string owner { get; set; }
    	}
    
    	public class Tires
    	{
    		public string front_value_mm { get; set; }
    		public string back_value_mm { get; set; }
    		public bool front_back { get; set; }
    	}
    }
