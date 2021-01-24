    using System;
    using System.Xml.Serialization;
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var o = new FlightPlan();
                var serializer = new XmlSerializer(typeof(FlightPlan));
                serializer.Serialize(Console.Out, o);
            }
        }
    }
