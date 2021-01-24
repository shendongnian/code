    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                StringBuilder sb = new StringBuilder();
    
                CityList cityList = new CityList();
                XmlSerializer serializer = new XmlSerializer(typeof(CityList));
                using (FileStream fileStream = new FileStream("database.txt", FileMode.Open))
                {
                    cityList = (CityList)serializer.Deserialize(fileStream);
                }
    
                using (StreamReader file = new StreamReader("file.txt"))
                {
                    string line;
                    while ((line = file.ReadLine()) != null)
                    {
                        if (!cityList.cities.Any(line.Contains))
                            sb.AppendLine(line);
                    }
                }
    
                File.WriteAllText("file.txt", sb.ToString());
            }
        }
    
    
        [XmlRoot("city-group")]
        public class CityList
        {
            [XmlElement("city")]
            public string[] cities { get; set; }
        }
    }
