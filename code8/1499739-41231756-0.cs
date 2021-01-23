    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    
    namespace XMLNodeAttributeSearch_41228129
    {
        class Program
        {
            static void Main(string[] args)
            {
                string filepath = @"M:\StackOverflowQuestionsAndAnswers\XMLNodeAttributeSearch_41228129\XMLNodeAttributeSearch_41228129\sample.xml";
                Update(filepath);
            }
    
            public static void Update(string incomingFilePath)
            {
                XDocument theDoc = XDocument.Load(incomingFilePath, LoadOptions.None);
    
                List<XElement> ClusterElements = theDoc.Descendants("IcMDetails").ToList();
                foreach (XElement item in ClusterElements)
                {
                    if (item.Attribute((XName)"Cluster").Value == "ClusterA")
                    {
                        string incidentid = item.Element((XName)"IncidentId").Value;
                        Console.WriteLine(incidentid);
                    }
                    else if (item.Attribute((XName)"Cluster").Value == "ClusterB")
                    {
                        string incidentid = item.Element((XName)"IncidentId").Value;
                        Console.WriteLine(incidentid);
                    }
                }
                Console.ReadLine();
            }
    
    
        }
    }
