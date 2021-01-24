    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Xml;
    using System.Xml.Serialization;
    using System.Xml.Schema;
    using System.IO;
    namespace XMLSerialize
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                AppConfig config = new AppConfig();
                config.Charts = new List<ChartGeneric>();
                Pie newPie = new Pie();
                config.Charts.Add(newPie);
                newPie.Attribute3 = "abc";
                StackedBar newStack = new StackedBar();
                config.Charts.Add(newStack);
                newStack.Attribute1 = "ghi";
                newStack.Attribute2 = "jkl";
                XmlSerializer serializer = new XmlSerializer(typeof(AppConfig));
                StreamWriter writer = new StreamWriter(FILENAME);
                serializer.Serialize(writer, config);
                writer.Flush();
                writer.Close();
                writer.Dispose();
                GetConfig(FILENAME);
            }
            public static AppConfig GetConfig(String filepath)
            {
                XmlSerializer xs = new XmlSerializer(typeof(AppConfig));
                XmlTextReader reader = new XmlTextReader(filepath);
                AppConfig configData = (AppConfig)xs.Deserialize(reader);
                return configData;
            }
        }
        [Serializable, XmlRoot("Configuration")]
        public class AppConfig
        {
            [XmlArray("Charts")]
            public List<ChartGeneric> Charts;
            [XmlElement("AnotherElement", Form = XmlSchemaForm.Unqualified)]
            public XmlElement[] AnotherElement { get; set; }
            [XmlElement("OneElement", Form = XmlSchemaForm.Unqualified)]
            public XmlElement[] OneElement { get; set; }
        }
        [XmlInclude(typeof(Pie))]
        [XmlInclude(typeof(StackedBar))]
        [Serializable]
        public class ChartGeneric
        {
            public string Attribute1 { get; set; }
            public string Attribute2 { get; set; }
        }
        [Serializable]
        [XmlRoot(ElementName = "Pie")]
        public class Pie : ChartGeneric
        {
            [XmlAttribute]
            public string Attribute3 { get; set; }
        }
        [Serializable]
        [XmlRoot(ElementName = "StackedBar")]
        public class StackedBar : ChartGeneric
        {
            [XmlAttribute]
            public string Attribute4 { get; set; }
        }
    }
