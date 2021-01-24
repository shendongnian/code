    public class Program
    {
        public int Id { get; set; }
        public bool IsRead { get; set; }
        public bool IsWrite { get; set; }
    }
    public class XmlTemplate
    {
        public List<Program> Programs { get; set; }
    }
    class MainProgram
    {
        static void Main(string[] args)
        {
            var xmlTemplate = new XmlTemplate();
            xmlTemplate.Programs = new List<Program>();
            xmlTemplate.Programs.Add(new Program() { Id = 123, IsRead = true, IsWrite = false });
            xmlTemplate.Programs.Add(new Program() { Id = 456, IsRead = false, IsWrite = true });
            var serializer = new XmlSerializer(typeof(XmlTemplate));
            var stream = new StringWriter();
            serializer.Serialize(stream, xmlTemplate);
            Console.WriteLine(stream.ToString());
            Console.ReadKey();
        }
    }
