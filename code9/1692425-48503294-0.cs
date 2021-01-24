    public class Departement {
         [XmlElement (Namespace = "http://tempuri.org/")]
         string Id;
         [XmlArray("Students", Namespace = "http://tempuri.org/")]
         [XmlArrayItem("Student")]
         List<Student> listStident = new List<Student> ();
     }
