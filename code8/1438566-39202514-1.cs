    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.0.30319.1")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "C")]
    public partial class OCITable
    {
        private string[] colHeadingField;
        [System.Xml.Serialization.XmlElementAttribute("colHeading", Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public string[] colHeading
        {
            get
            {
                return this.colHeadingField;
            }
            set
            {
                this.colHeadingField = value;
            }
        }
        [System.Xml.Serialization.XmlElement(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public OCITableRow [] row { get; set; }
    }
    public class OCITableRow
    {
        [System.Xml.Serialization.XmlElementAttribute("col", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        public string[] col { get; set; }
    }
