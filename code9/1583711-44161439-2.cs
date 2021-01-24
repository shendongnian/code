	public class nbrOfQualifiers
	{
		public int Value { get; set; }
		public string Qualifier { get; set; }
	}
	
	public class RequestServiceNumberOfQualifiers
	{
		public List<List<nbrOfQualifiers>> numberOfQualifiers { get; set; } // note that I have
                                                                            // List<List<T>>
	}
