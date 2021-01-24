    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    namespace ConsoleApplication73
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(forms));
                StreamReader reader = new StreamReader(FILENAME);
                forms _forms = (forms)serializer.Deserialize(reader);
            }
        }
        [XmlRoot("forms")]
        public class forms
        {
            private string siteField;
            private string export_dateField;
            private formsWebform[] webformField;
            [XmlElement("site")]
            public string site
            {
                get
                {
                    return this.siteField;
                }
                set
                {
                    this.siteField = value;
                }
            }
            [XmlElement("export_date")]
            public string export_date
            {
                get
                {
                    return this.export_dateField;
                }
                set
                {
                    this.export_dateField = value;
                }
            }
            [XmlElement("webform")]
            public formsWebform[] webform
            {
                get
                {
                    return this.webformField;
                }
                set
                {
                    this.webformField = value;
                }
            }
        }
        [XmlRoot("webform")]
        public partial class formsWebform
        {
            private string crmFormIdField;
            private string versionField;
            private formsWebformFormData formDataField;
            private string nameField;
            [XmlElement("crmFormId")]
            public string crmFormId
            {
                get
                {
                    return this.crmFormIdField;
                }
                set
                {
                    this.crmFormIdField = value;
                }
            }
            [XmlElement("version")]
            public string version
            {
                get
                {
                    return this.versionField;
                }
                set
                {
                    this.versionField = value;
                }
            }
            [XmlElement("formData")]
            public formsWebformFormData formData
            {
                get
                {
                    return this.formDataField;
                }
                set
                {
                    this.formDataField = value;
                }
            }
            //[XmlElement("field")]
            //public string name
            //{
            //    get
            //    {
            //        return this.nameField;
            //    }
            //    set
            //    {
            //        this.nameField = value;
            //    }
            //}
        }
        [XmlRoot("formData")]
        public partial class formsWebformFormData
        {
            private string wEBFORMNODESTATUSField;
            [XmlElement("WEBFORMNODESTATUS")]
            public string WEBFORMNODESTATUS
            {
                get
                {
                    return this.wEBFORMNODESTATUSField;
                }
                set
                {
                    this.wEBFORMNODESTATUSField = value;
                }
            }
            private SubmittedDataFields submittedDataField;
            [XmlElement("submittedData")]
            public SubmittedDataFields submittedData
            {
                get
                {
                    return this.submittedDataField;
                }
                set
                {
                    this.submittedDataField = value;
                }
            }
        }
        [XmlRoot("submittedData")]
        public partial class SubmittedDataFields
        {
            private formsWebformFormDataSubmittedDataField[] data;
            [XmlElement("field")]
            public formsWebformFormDataSubmittedDataField[] fields
            {
                get
                {
                    return this.data;
                }
                set
                {
                    this.data = value;
                }
            }
        }
        [XmlRoot("field")]
        public partial class formsWebformFormDataSubmittedDataField
        {
            private string crmFieldKeyField;
            private string crmFieldValueField;
            [XmlElement("submittedData")]
            public string crmFieldKey
            {
                get
                {
                    return this.crmFieldKeyField;
                }
                set
                {
                    this.crmFieldKeyField = value;
                }
            }
            [XmlElement("crmFieldValue")]
            public string crmFieldValue
            {
                get
                {
                    return this.crmFieldValueField;
                }
                set
                {
                    this.crmFieldValueField = value;
                }
            }
        }
    }
