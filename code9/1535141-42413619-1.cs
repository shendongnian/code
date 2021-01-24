    using System;
    using System.Xml.Serialization;
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var serializer = new XmlSerializer(typeof(FlightPlan));
                // Deserialize
                FlightPlan o = (FlightPlan)
                    serializer.Deserialize(new StreamReader("source.xml"));
                // Serialize
                serializer.Serialize(new StreamWriter("Out.xml"), o);
            }
        }
    }
