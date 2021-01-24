    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication7
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                new XmlParser(FILENAME);
            }
        }
        public class Cyclist
        {
            public string Name { get; set; }
            public string gender { get; set; }
            public string type { get; set; }
            public  int countryFK { get; set; }
            public int enetID { get; set; }
            public string enetSportID { get; set; }
            public string del { get; set; }
            public int n { get; set; }
            public int id { get; set; }
            public DateTime ut { get; set; }
            public List<Result> results { get; set; }
        }
        public class Result
        {
            public int event_participantsFK { get; set; }
            public int result_typeFK { get; set; }
            public string result_code { get; set; }
            public string value { get; set; }
            public string del { get; set; }
            public int n { get; set; }
            public DateTime ut { get; set; }
            public int id { get; set; }
        }
        public class XmlParser
        {
            public List<Cyclist> participants = new List<Cyclist>();
            public string typeOfSport { get; set; }
            public XDocument doc { get; set; }
            public DateTime startDate { get; set; }
            public DateTime endDate { get; set; }
            public XmlParser(string fileName)
            {
                doc = XDocument.Load(fileName);
                getParticipants();
                //getEventStartDate_EndDate();
                //getTypeOfSport();
            }
            public void getParticipants()
            {
                if (doc != null)
                {
                    IEnumerable<Cyclist> decendants = doc.Descendants("event_participant").Select(c => new Cyclist() {
                        Name = (string)c.Element("participant").Attribute("name"),
                        gender = (string)c.Element("participant").Attribute("gender"),
                        type = (string)c.Element("participant").Attribute("type"),
                        countryFK = (int)c.Element("participant").Attribute("countryFK"),
                        enetID = (int)c.Element("participant").Attribute("enetID"),
                        enetSportID = (string)c.Element("participant").Attribute("enetSportID"),
                                         
                                         
                        del = (string)c.Element("participant").Attribute("del"),
                        n = (int)c.Element("participant").Attribute("n"),
                        id = (int)c.Element("participant").Attribute("id"),
                        ut = (DateTime)c.Element("participant").Attribute("ut"),
                        results = c.Descendants("result").Select(y => new Result() {
                            event_participantsFK = (int)y.Attribute("event_participantsFK"),
                            result_typeFK = (int)y.Attribute("result_typeFK"),
                            result_code = (string)y.Attribute("result_code"),
                            value = (string)y.Attribute("value"),
                            del = (string)y.Attribute("del"),
                            n = (int)y.Attribute("n"),
                            ut = (DateTime)y.Attribute("ut"),
                            id = (int)y.Attribute("id")
                        }).ToList()
                    }).ToList();
                }
            }
        }
    }
