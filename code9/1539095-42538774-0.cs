    public static void JsonToDateTime()
    {
    	var dateObj = new DateTest { Date = "/Date(1488393000000-0500)/" };
    	var jsonDate = JsonConvert.SerializeObject(dateObj.Date);
    	var output = JsonConvert.DeserializeObject<DateTime>(jsonDate);
    
    }
    
    public class DateTest
    {
    	public string Date { get; set; }
    }
