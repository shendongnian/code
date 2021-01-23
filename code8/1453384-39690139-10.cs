    public class Program
    {
        public static void Main(string[] args)
        {
            string json = @"
            {
              ""doctor"": {
                ""name"": ""Dr. Herbert Q. Cunningham III""
              },
              ""patients"": {
                ""name"": [
                  ""Joe Schmoe"",
                  ""John Doe"",
                  ""Steve Smith""
                ]
              }
            }";
            var serializer = new JavaScriptSerializer();
            serializer.RegisterConverters(new List<JavaScriptConverter> { new NameObjectConverter() });
            MedicalData data = serializer.Deserialize<MedicalData>(json);
            Console.WriteLine("Doctor's name: " + data.Doctor.Name);
            Console.WriteLine("Patients' names: ");
            foreach (string name in data.Patients.Names)
            {
                Console.WriteLine("  " + name);
            }
        }
    }
    public class MedicalData
    {
        public NameObject Doctor { get; set; }
        public NameObject Patients { get; set; }
    }
