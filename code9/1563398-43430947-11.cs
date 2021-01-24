    [XmlRoot("ArrayOfEducation", Namespace = "http://schemas.datacontract.org/2004/07/CovUni.Domain.Admissions")]
     public class ArrayOfEducation
     {
      [XmlElement("Education")]
      public ContainerEducation education { get; set; }
     }
