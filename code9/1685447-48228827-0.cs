    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    namespace Work
    {
        public class Program
        {
            public static void Main(string[] _)
            {
                var folder = AppDomain.CurrentDomain.BaseDirectory;
                var path = Path.Combine(folder, "Data.xml");
                var xml = XElement.Load(path);
                var prop = xml.Elements("Component")
                    .Where(c => c.Attribute("ProductId").Value == "ERDSIC")
                    .Descendants("Row").Where(t => t.Attribute("Name").Value == "dampersize")
                    .Select(v => v.Attribute("Value").Value).FirstOrDefault();
                Console.WriteLine("Result: " + prop);
                Console.ReadKey();
            }
        }
    }
