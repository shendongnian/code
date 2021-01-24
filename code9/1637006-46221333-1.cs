    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication4
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.ConformanceLevel = ConformanceLevel.Fragment;
                XmlReader reader = XmlReader.Create(FILENAME,settings);
                while (!reader.EOF)
                {
                    try
                    {
                        if (reader.Name != "LOG_x0020_ParityRate")
                        {
                            reader.ReadToFollowing("LOG_x0020_ParityRate");
                        }
                        if (!reader.EOF)
                        {
                            XElement parityRate = (XElement)XElement.ReadFrom(reader);
                            ParityRate newLog = new ParityRate();
                            ParityRate.logs.Add(newLog);
                            newLog.date = DateTime.ParseExact((string)parityRate.Element("DATE"), "MM/dd/yyyy - hh:mm", System.Globalization.CultureInfo.InvariantCulture);
                            newLog.name = (string)parityRate.Element("CHANNELNAME");
                            newLog.sql = (string)parityRate.Element("SQL");
                            newLog.hotel = (int)parityRate.Element("ID_HOTEL");
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
        }
        public class ParityRate
        {
            public static List<ParityRate> logs = new List<ParityRate>();
            public DateTime date { get; set; }
            public string name { get; set; }
            public string sql { get; set; }
            public int hotel { get; set; }
        }
    }
