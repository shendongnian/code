    internal static class ct
    {
     public const string nsImmutable = "http://www.digitalmeasures.com/schema/immutable";
     public const string nsXLink = "http://www.w3.org/1999/xlink";
    }
    
    [Serializable]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public partial class Roles
    {
      [XmlElement("Role", typeof(no.Role))]
      [XmlElement("Role", typeof(imm.Role), Namespace = ct.nsImmutable)]
      public object[] Items { get; set; }
    }
    public partial class BaseRole
    {
      [XmlAttribute("roleKey")]
      public string RoleKey { get; set; }
      [XmlAttribute("text")]
      public string Text { get; set; }
    }
      [Serializable]
      [XmlType(AnonymousType = true)]
      //[XmlRoot(Namespace = "", IsNullable = false)]
      public partial class CT
      {
        [XmlAttribute(Form = XmlSchemaForm.Qualified, Namespace = ct.nsXLink, AttributeName = "type")]
        public string Type { get; set; }
        [XmlAttribute(Form = XmlSchemaForm.Qualified, Namespace = ct.nsXLink, AttributeName = "href")]
        public string Href { get; set; }
      }
    namespace imm
    {
      [Serializable]
      [XmlType(AnonymousType = true, Namespace = ct.nsImmutable)]
      [XmlRoot(Namespace = ct.nsImmutable, IsNullable = false)]
      public partial class Role : BaseRole
      {
        [XmlElement(Namespace = "", Type = typeof(CT), ElementName = "Item")]
        public CT Item { get; set; }
        [XmlElement(Namespace = "", Type = typeof(CT), ElementName = "Users")]
        public CT Users { get; set; }
      }      
    }
    namespace no
    {
      [Serializable]
      [XmlType(AnonymousType = true)]
      public partial class Role : BaseRole
      {
        [XmlElement("Item", typeof(CT))]
        public CT Item { get; set; }
        [XmlElement("Users", typeof(CT))]
        public CT Users { get; set; }
      }
    }
  
