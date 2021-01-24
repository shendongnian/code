    public class Programs
    {
        public int Id { get; set; }
        public bool IsRead { get; set; }
        public bool IsWrite { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var programs = new Programs
            {
                Id = 123,
                IsRead = true,
                IsWrite = false
            };
            var serializer = new XmlSerializer(typeof(Programs));
            var stream = new StringWriter();
            serializer.Serialize(stream, programs);
            Console.WriteLine(stream.ToString());
            Console.ReadKey();
        }
    }
