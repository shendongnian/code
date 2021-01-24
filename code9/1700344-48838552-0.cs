    using System;
    using System.Xml;
    using System.Xml.Serialization;
    // Represents the <Race> XML tag.
    [XmlRoot("Race")]
    class Race
    {
        // Because the <Checkpoints> tag is contained by the <Race> tag,
        // the class representation of the <Checkpoints> tag should be contained
        // by the class representation of the <Race> tag.
        [XmlElement(ElementName = "Checkpoints")]
        public Checkpoints Checkpoints { get; set; }
    }
    // Represents a <Checkpoints> XML tag.
    [XmlRoot("Vector3")]
    class Checkpoints 
    {
        // Same as above but for <Vector3> tags.
        [XmlElement(ElementName = "Vector3")]
        public List<Vector3> Vectors { get; set; }
    }
    // Represents a <Vector3> XML tag.
    [XmlRoot("Vector3")]
    class Vector3 
    {
        // The <X> element in the <Vector3> tag
        [XmlElement(ElementName = "X")]
        public double X { get; set; }
        // Same
        [XmlElement(ElementName = "Y")]
        public double Y { get; set; }
        // Same
        [XmlElement(ElementName = "Z")]
        public double Z { get; set; }
    }
