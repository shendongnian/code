    using System;
    using System.Xml;
    using System.Xml.XPath;
    using System.Xml.Serialization;
    namespace XMLTest1
    {
        public class Test
        {
            public String value1;
            public String value2;
        }
    
        class listtest
        {
            static void Main(string[] args)
            {
                XmlDocument myXml = new XmlDocument();
                XPathNavigator xNav = myXml.CreateNavigator();
                Test myTest = new Test() { value1 = "Value 1", value2 = "Value 2" };
                XmlSerializer x = new XmlSerializer(myTest.GetType());
                using (var xs = xNav.AppendChild())
                {
                    x.Serialize(xs, myTest);
                }
                Console.WriteLine(myXml.OuterXml);
                Console.ReadKey();
            }
        } }
