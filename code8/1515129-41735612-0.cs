    public class QuoteReport: IReport
    {
      public String DeviceType { get; set; }
      public String ProductName { get; set; }
      public String Description { get; set; }
      public String ID { get; set; }
      public String Address { get; set; }  
	  
      public void Generate(List<int> ids)
	  {
			// create "itself"
	  }   
    }
