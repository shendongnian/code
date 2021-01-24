    [XmlRoot("EmployeeDetail")]
    public class EmployeeCollection
    {
    	[XmlElementAttribute("Employee")]	
    	public Employee[] Employee { get; set; }
    }
