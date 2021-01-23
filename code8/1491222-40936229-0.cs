    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication29
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ConformanceLevel = ConformanceLevel.Fragment;
                
                XmlReader reader = XmlTextReader.Create(FILENAME,settings);
                List<object> results = new List<object>();
                while (!reader.EOF)
                {
                    if (reader.Name != "row")
                    {
                        reader.ReadToFollowing("row");
                    }
                    if (!reader.EOF)
                    {
                        XElement row = (XElement)XElement.ReadFrom(reader);
                        results.Add(new object[] {
                            row.Elements("column").Select(y => new {
                                rowNum = (int)row.Attribute("rownum"),
                                colNum = (int)y.Attribute("colnum"),
                                colName = (string)y.Attribute("name"),
                                value = (string)y
                            }).FirstOrDefault()
                        });
                    }
                }
            }
     
        }
    }
