    public static class Program
    {
        public class Employee
        {
            public string Salary1 { get; set; }
            public string Salary2 { get; set; }
        }
        public static class Database
        {
            public static int? Salary1 = 100;
            public static int? Salary2 = 50;
        }
        public static void Main(string[] args)
        {
            XmlSerializer xsSubmit = new XmlSerializer(typeof(Employee));
            Employee subReq;
            if (Database.Salary1 > Database.Salary2)
            {
                subReq = new Employee { Salary1 = Database.Salary1.ToString() };
            }
            else
            {
                subReq = new Employee { Salary2 = Database.Salary2.ToString() };
            }
            var xml = "";
            using (var sww = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sww))
                {
                    xsSubmit.Serialize(writer, subReq);
                    xml = sww.ToString(); // Your XML
                }
            }
            Console.WriteLine(xml);
            Console.ReadLine();
        }
    }
