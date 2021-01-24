    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public partial class bla
    {
        public blaListOfListOfTest ListOfListOfTest { get; set; }
    }
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class blaListOfListOfTest
    {
        public blaListOfListOfTestListOfTest ListOfTest { get; set; }
    }
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class blaListOfListOfTestListOfTest
    {
        public object Test { get; set; }
    }
