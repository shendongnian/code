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
            Citites cities;
            using (StreamReader reader = new StreamReader("database.xml"))
            {
                var xs = new XmlSerializer(typeof(Citites));
                cities = (Citites)xs.Deserialize(reader);
            }
            string tempFile = Path.GetTempFileName();
            using (StreamReader rw = new StreamReader("file.txt"))
            using (var sw = new StreamWriter(tempFile))
            {
                {
                    while (rw.Peek() > 0)
                    {
                        string city = rw.ReadLine();
                        if (!cities.City.Contains(city))
                        {
                            sw.WriteLine(city);
                        }
                    }
                }
            }
            File.Delete("file.txt");
            File.Move(tempFile, "file.txt");
        }
    }
