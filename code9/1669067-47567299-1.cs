    using System;
    using System.Xml.Serialization;
    using System.Collections.Generic;
    using System.IO;
    
    namespace ConsoleWinForm
    {
        [XmlRoot(ElementName = "id")]
        public class Id
        {
            [XmlAttribute(AttributeName = "value")]
            public string Value { get; set; }
        }
    
        [XmlRoot(ElementName = "Module")]
        public class Module
        {
            [XmlElement(ElementName = "id")]
            public List<Id> Id { get; set; }
            [XmlAttribute(AttributeName = "Name")]
            public string Name { get; set; }
            [XmlAttribute(AttributeName = "Path")]
            public string Path { get; set; }
        }
    
        [XmlRoot(ElementName = "identifiers")]
        public class Identifiers
        {
            [XmlElement(ElementName = "Module")]
            public Module Module { get; set; }
        }
    
        public class Program
        {
            public static void Main()
            {
                string xml = @"<?xml version=""1.0"" encoding=""UTF-8""?>
                                <identifiers> 
                                <Module Name=""Doors_Module1"" Path=""Doors_Module1 "">
                                    <id value=""16""/>
                                    <id value=""15""/>
                                    <id value=""14""/>
                                    <id value=""13""/>
                                    <id value=""12""/>
                                    <id value=""11""/>
                                    <id value=""10""/>
                                    <id value=""9""/>
                                    <id value=""17""/>
                                    <id value=""8""/>
                                    <id value=""7""/>
                                    <id value=""6""/>
                                    <id value=""5""/>
                                    <id value=""4""/>
                                    <id value=""3""/>
                                    <id value=""2""/>
                                    <id value=""1""/>
                                </Module>
                                </identifiers>";
    
                using (var rdr = new StringReader(xml))
                {
                    var srlzr = new XmlSerializer(typeof(Identifiers));
                    var result = srlzr.Deserialize(rdr) as Identifiers;
                }
            }
        }
    }
