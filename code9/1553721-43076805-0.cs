    using System.IO;
    using System.Linq;
    using System.Xml.Linq;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main()
            {
                string[] lines = File.ReadAllLines(@"C:\CSVOutput.csv");
    
                XElement xml = new XElement("Part",
                    from str in lines
                    let columns = str.Split(',')
                    select new XElement("New Part",
                        new XElement("Manufacturer", columns[0]),
                        new XElement("MPN", columns[1]),
                        new XElement("Description", columns[2]),
                        new XElement("Quantity on Hand ", columns[3]),
                        new XElement("U/M", columns[4]),
                        new XElement("Cost", columns[5])
                    )
                );
    
                xml.Save(@"C:\XMLOutputFile.xml");
            }
        }
    }
