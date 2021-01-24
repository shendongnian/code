    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    
    namespace MyXML
    {
        // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class Root
        {
    
            private RootStorageObject storageObjectField;
    
            /// <remarks/>
            public RootStorageObject StorageObject
            {
                get
                {
                    return this.storageObjectField;
                }
                set
                {
                    this.storageObjectField = value;
                }
            }
        }
    
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class RootStorageObject
        {
    
            private RootStorageObjectProperty[] propertiesField;
    
            private string nameField;
    
            private string idField;
    
            private string typeField;
    
            /// <remarks/>
            [System.Xml.Serialization.XmlArrayItemAttribute("Property", IsNullable = false)]
            public RootStorageObjectProperty[] Properties
            {
                get
                {
                    return this.propertiesField;
                }
                set
                {
                    this.propertiesField = value;
                }
            }
    
            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }
    
            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Id
            {
                get
                {
                    return this.idField;
                }
                set
                {
                    this.idField = value;
                }
            }
    
            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Type
            {
                get
                {
                    return this.typeField;
                }
                set
                {
                    this.typeField = value;
                }
            }
        }
    
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class RootStorageObjectProperty
        {
    
            private string nameField;
    
            private string valueField;
    
            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }
    
            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Value
            {
                get
                {
                    return this.valueField;
                }
                set
                {
                    this.valueField = value;
                }
            }
        }
    
    
    
    }
