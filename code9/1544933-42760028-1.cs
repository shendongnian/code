    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class bla
    {
        private blaListOfListOfTest listOfListOfTestField;
        public blaListOfListOfTest ListOfListOfTest
        {
            get { return this.listOfListOfTestField; }
            set { this.listOfListOfTestField = value; }
        }
    }
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class blaListOfListOfTest
    {
        private blaListOfListOfTestListOfTest listOfTestField;
        public blaListOfListOfTestListOfTest ListOfTest
        {
            get { return this.listOfTestField; }
            set { this.listOfTestField = value; }
        }
    }
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class blaListOfListOfTestListOfTest
    {
        private object testField;
        public object Test
        {
            get { return this.testField; }
            set { this.testField = value; }
        }
    }
