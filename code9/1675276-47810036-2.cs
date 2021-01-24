    public class Employee
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
    }
    public static void Main(string[] args)
    {
        var employee = new Employee();
        var sw = new StringWriter();
        var se = new XmlSerializer(employee.GetType());
        var tw = new XmlTextWriter(sw);
        se.Serialize(tw, employee);
        Console.WriteLine(sw.ToString());
        Console.Read();
    }
