     class Program
    {         
     static void Main(string[] args)
        {   
            Details details = new Details();
            details.ID = new Guid();
            details.Name = "testuser";
            details.Status = true;
            details.History = new List<DataPoint>();
            details.History.Add(new DataPoint() {Name = "test"});
            details.History.Add(new DataPoint() { Name = "test1" });
            details.History.Add(new DataPoint() { Name = "test2" });
            details.History.Add(new DataPoint() { Name = "test3" });
            Serialize(details);
            }
 
    private static void Serialize(Details details)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Details));
            using (TextWriter writer = new StreamWriter(@"C:\Users\testuser\Desktop\Xml.xml"))
            {
                serializer.Serialize(writer, details);
            }
        }
    }
    public  class Details
    {
       
        public Guid ID { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public List<DataPoint> History { get; set; } = new List<DataPoint>();
    }
    public class DataPoint
    {
        public string Name { get; set; }
    }
