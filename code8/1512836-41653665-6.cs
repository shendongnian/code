        public class test
        {
            [XmlElement(Namespace = "http://schemas.microsoft.com/office/infopath/2003/dataFormSolution")]
            public string raz { get; set; }
            [XmlElement(Namespace = "http://schemas.microsoft.com/office/infopath/2003/dataFormSolution")]
            public string dwa { get; set; }
        }
    
        public class Osoba
        {
            [XmlElement(Namespace = "http://schemas.microsoft.com/office/infopath/2007/PartnerControls")]
            public test tehe { get; set; }
        }
