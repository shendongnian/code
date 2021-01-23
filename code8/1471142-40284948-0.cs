    [System.SerializableAttribute()]
    public partial class ListOfStudents
    {
        [System.Xml.Serialization.XmlElementAttribute("ClassOfStudents")]
        public ListOfStudentsClassOfStudents[] ClassOfStudents { get; set; }
    }
      
    
    /// <remarks/>
    [System.SerializableAttribute()]
    public partial class ListOfStudentsClassOfStudents
    {
         [System.Xml.Serialization.XmlElementAttribute("Student")]
        public ListOfStudentsClassOfStudentsStudent[] Student { get; set; }
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public byte value { get; set; }
    
    }
    
    /// <remarks/>
    [System.SerializableAttribute()]
    public partial class ListOfStudentsClassOfStudentsStudent
    {
         [System.Xml.Serialization.XmlAttributeAttribute()]
        public string first { get; set; }
         [System.Xml.Serialization.XmlAttributeAttribute()]
        public string last { get; set; }
       
    }
