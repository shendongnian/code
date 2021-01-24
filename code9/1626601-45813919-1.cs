    public class Employees
    {
        [XmlElement(typeof(IT))]
        [XmlElement(typeof(HR))]
        public List<Employee> Employee { get; set; } //It doesn't really matter what this field is named, it takes the class name in the serialization
    }
