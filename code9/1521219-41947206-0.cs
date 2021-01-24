    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    
    namespace GenericTesting.Models
    {
      [Serializable()]
      public class Location
      {                                                                                
        [XmlAttribute()]
        public int Id { get; set; }
        [XmlAttribute()]
        public double PercentUsed { get; set; }
        [XmlElement]
        public string ExtraGarbage { get; set; }
        [XmlText]
        public string UsedOnceInTheUniverse { get; set; }
      }
    }
