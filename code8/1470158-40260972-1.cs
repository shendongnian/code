    public class DateTest
    {
    	[JsonConverterAttribute(typeof(DateTimeConverter))]
    	public DateTime? MyDateTime { get; set;}
    
    	[JsonConverterAttribute(typeof(DateTimeConverter))]
    	public DateTime? MyDateTime1 { get; set; }
    }
    void Main()
    {
    	DateTest dateTest = new DateTest 
    	{ 
    	  MyDateTime = DateTime.MinValue, 
    	  MyDateTime1 = DateTime.MaxValue
    	};
    	
    	Console.WriteLine(JsonConvert.SerializeObject(dateTest));
    }
