    class Program
    {
        static void Main(string[] args)
        {
            var csv = new CsvReader(File.OpenText("Path_to_your_csv_file"));
            csv.Configuration.IgnoreHeaderWhiteSpace = true;
            csv.Configuration.RegisterClassMap<MyCustomObjectMap>();
            var myCustomObjects = csv.GetRecords<MyCustomObject>();
            foreach (var item in myCustomObjects.ToList())
            {
                // Apply your application logic here.
                Console.WriteLine(item.Name);
            }
        }
    }
    public class MyCustomObject
    {
        // Note: You may want to use a type converter to convert the ID to an integer.
        public string ID { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Website { get; set; }
        public override string ToString()
        {
            return Name.ToString();
        }
    }
    public sealed class MyCustomObjectMap : CsvClassMap<MyCustomObject>
    {
        public MyCustomObjectMap()
        {
            // In the name method, you provide the header text - i.e. the header value set in the first line of the CSV file.
            Map(m => m.ID).Name("id");
            Map(m => m.Name).Name("name");
            Map(m => m.Lastname).Name("lastname");
            Map(m => m.Phone).Name("phone");
            Map(m => m.Mail).Name("mail");
            Map(m => m.Website).Name("website");
        }
    }
