    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                IMAApplications applications = Deserialize(FILENAME);
            }
            static IMAApplications Deserialize(string configFilePath)
            {
                IMAApplications appConfig = null;
                var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, configFilePath);
                var xRoot = new XmlRootAttribute();
                xRoot.ElementName = "Applications";
                xRoot.IsNullable = true;
                var serializer = new XmlSerializer(typeof(IMAApplications), xRoot);
                using (var stream = File.OpenRead(path))
                    appConfig = (IMAApplications)serializer.Deserialize(stream);
                return appConfig;
            }
        }
        [XmlRoot("ProcessStep")]
        public class IMAProcessStep
        {
            private string name;
            private string vbaFunction;
            private string excelName;
            [XmlAttribute("Name")]
            public string Name
            {
                get { return name; }
                set { name = value; }
            }
            [XmlAttribute("VBAFunction")]
            public string VBAFunction
            {
                get { return vbaFunction; }
                set { vbaFunction = value; }
            }
            [XmlAttribute("ExcelName")]
            public string ExcelName
            {
                get { return excelName; }
                set { excelName = value; }
            }
        }
        [XmlRoot("InstrumentType")]
        public class IMAInstrumentType
        {
            [XmlAttribute("Name")]
            public string Name
            {
                get;
                set;
            }
            [XmlAttribute("Version")]
            public string Version
            {
                get;
                set;
            }
            [XmlAttribute("PrimaryKeyExcel")]
            public string PrimaryKeyExcel
            {
                get;
                set;
            }
        }
        [XmlRoot("Applications")]
        public class IMAApplications
        {
            [XmlElement("Application")]
            public List<IMAApplication> applications { get; set; }
        }
        [XmlRoot("Application")]
        public class IMAApplication
        {
            [XmlAttribute("Name")]
            public string Name { get; set; }
            [XmlAttribute("MakerCheckerType")]
            public string MakerCheckerType { get; set; }
            public bool IsMakerCheckerType
            {
                get
                {
                    if (MakerCheckerType == "Real")
                        return true;
                    return false;
                }
                set
                {
                    if (value)
                        MakerCheckerType = "Real";
                    else
                        MakerCheckerType = "Operational";
                }
            }
            [XmlAttribute("SanctionCheckNeeded")]
            public string SanctionCheckNeeded { get; set; }
            [XmlAttribute("PreExistCheckNeeded")]
            public string PreExistCheckNeeded { get; set; }
            public bool IsSanctionCheckNeeded
            {
                get
                {
                    return SanctionCheckNeeded == "Y";
                }
                set
                {
                    SanctionCheckNeeded = value ? "Y" : "N";
                }
            }
            public bool IsPreExistCheckNeeded
            {
                get
                {
                    if (PreExistCheckNeeded == "Y")
                        return true;
                    return false;
                }
                set
                {
                    if (value)
                        PreExistCheckNeeded = "Y";
                    else
                        PreExistCheckNeeded = "N";
                }
            }
            [XmlArray("ProcessSteps")]
            [XmlArrayItem(ElementName = "ProcessStep")]
            public List<IMAInstrumentType> SupportedInstrumentTypes { get; set; }
            [XmlArray("InstrumentTypes")]
            [XmlArrayItem(ElementName = "InstrumentType")]
            public List<IMAProcessStep> ProcessSteps { get; set; }
        }
    }
