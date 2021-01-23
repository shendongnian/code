    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    namespace QueryingXML_41271961
    {
        class Program
        {
            static void Main(string[] args)
            {
                string thePath = @"M:\StackOverflowQuestionsAndAnswers\QueryingXML_41271961\QueryingXML_41271961\sample.xml";
    
                XDocument theXMLDoc = XDocument.Load(thePath);
                List<XElement> theYears = theXMLDoc.Descendants("PRODUCTION").Elements("YEAR").ToList();
                List<InfoHolder> mylist = new List<InfoHolder>();
    
                foreach (XElement yearInXML in theYears)
                {
                    InfoHolder ih = new InfoHolder();
                    ih.years = yearInXML.Attribute("NUMBER").Value;
    
                    foreach (XElement monthsInYear in yearInXML.Elements("MONTH"))
                    {
                        if (ih.months == null)
                        {
                            ih.months = monthsInYear.Attribute("NUMBER").Value;
                        }
                        else
                        {
                            ih.months += "," + monthsInYear.Attribute("NUMBER").Value;
                        }
                    }
                    mylist.Add(ih);
                }
                System.Diagnostics.Debugger.Break();
            }
        }
    
        public class InfoHolder
        {
            public string years { get; set; }
            public string months { get; set; }
        }
    }
