    [XmlRoot("city-group")]
    public class Citites
    {
        [XmlElement("city")]
        public string[] City { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            // 1. read all city's name  from xml file
            Citites cities;
            using (StreamReader reader = new StreamReader("database.xml"))
            {
                var xs = new XmlSerializer(typeof(Citites));
                cities = (Citites)xs.Deserialize(reader);
            }
            // 2. read current file and open temp file for insert not matched city 
            string tempFile = Path.GetTempFileName();
            using (StreamReader rw = new StreamReader("file.txt"))
            using (var sw = new StreamWriter(tempFile))
            {
                {
                    // while of not end
                    while (rw.Peek() > 0)
                    {
                        // read next line
                        string city = rw.ReadLine();
                        if (!cities.City.Contains(city))
                        { 
                            // the city's name no matched, insert to temp file
                            sw.WriteLine(city);
                        }
                    }
                }
            }
            // 3. replace the current file with a temp file
            File.Delete("file.txt");
            File.Move(tempFile, "file.txt");
        }
    }
