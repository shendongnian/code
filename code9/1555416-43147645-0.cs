    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    using System.IO;
    namespace ConsoleApplication49
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(FeatureCollection));
                StreamReader reader = new StreamReader(FILENAME);
                FeatureCollection collection =  (FeatureCollection)serializer.Deserialize(reader);
            }
        }
        [XmlRoot(ElementName = "FeatureCollection", Namespace = "http://namespaces.os.uk/product/1.0", IsNullable = false)]
        public class FeatureCollection
        {
            [XmlElement(ElementName = "metadata", Namespace = "http://namespaces.os.uk/product/1.0")]
            public Metadata metadata  { get; set;}
            [XmlElement(ElementName = "featureMember", Namespace = "http://namespaces.os.uk/product/1.0", IsNullable = false)]
            public FeatureMember featureMember { get; set; }
        }
        [XmlRoot(ElementName = "metadata", Namespace = "http://namespaces.os.uk/product/1.0", IsNullable = false)]
        public class Metadata
        {
        }
        [XmlRoot(ElementName = "featureMember", Namespace = "http://namespaces.os.uk/product/1.0", IsNullable = false)]
        public class FeatureMember
        {
            [XmlElement(ElementName = "TurnRestriction", Namespace = "http://namespaces.os.uk/mastermap/routingAndAssetManagement/2.0", IsNullable = false)]
            public TurnRestriction turnRestriction { get; set; }
        }
        [XmlRoot(ElementName = "TurnRestriction", Namespace = "http://namespaces.os.uk/mastermap/routingAndAssetManagement/2.0", IsNullable = false)]
        public class TurnRestriction
        {
            [XmlElement(ElementName = "identifier", Namespace = "http://www.opengis.net/gml/3.2", IsNullable = false)]
            public Identifier identifier { get; set; }
            [XmlElement(ElementName = "networkRef", Namespace = "http://inspire.ec.europa.eu/schemas/net/4.0")]
            public NetworkRef[] networkRef { get; set; }
        }
        [XmlRoot(ElementName = "identifier", Namespace = "http://www.opengis.net/gml/3.2", IsNullable = false)]
        public class Identifier
        {
        }
        [XmlRoot(ElementName = "networkRef", Namespace = "http://inspire.ec.europa.eu/schemas/net/4.0", IsNullable = false)]
        public class NetworkRef
        {
            [XmlElement("LinkReference", Namespace = "http://inspire.ec.europa.eu/schemas/net/4.0")]
            public LinkReference linkReference { get; set; }
        }
       [XmlRoot(ElementName = "LinkReference", Namespace = "http://inspire.ec.europa.eu/schemas/net/4.0", IsNullable = false)]
        public class LinkReference
        {
            [XmlElement("element", Namespace = "http://inspire.ec.europa.eu/schemas/net/4.0")]
            public Element element { get; set; }
        }    
        [XmlRoot(ElementName = "element", Namespace = "http://inspire.ec.europa.eu/schemas/net/4.0", IsNullable = false)]
        public class Element
        {
        }   
       
    }
