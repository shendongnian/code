    namespace Question42295155 {
        
        
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("XsdToClassTest", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=true)]
        public partial class SimleSampleClass {
            
            private System.Nullable<decimal> somethingField;
            
            /// <remarks/>
            public System.Nullable<decimal> Something {
                get {
                    return this.somethingField;
                }
                set {
                    this.somethingField = value;
                }
            }
        }
        
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("XsdToClassTest", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=true)]
        public partial class SampleClass {
            
            private System.Nullable<decimal> somethingField;
            
            private System.Nullable<SomeEnum> someEnumField;
            
            private string someStringField;
            
            private System.Nullable<decimal> someNullableField;
            
            private System.Nullable<System.DateTime> someDateTimeField;
            
            private XmlColor myColorField;
            
            private long idField;
            
            /// <remarks/>
            public System.Nullable<decimal> Something {
                get {
                    return this.somethingField;
                }
                set {
                    this.somethingField = value;
                }
            }
            
            /// <remarks/>
            public System.Nullable<SomeEnum> SomeEnum {
                get {
                    return this.someEnumField;
                }
                set {
                    this.someEnumField = value;
                }
            }
            
            /// <remarks/>
            public string SomeString {
                get {
                    return this.someStringField;
                }
                set {
                    this.someStringField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
            public System.Nullable<decimal> SomeNullable {
                get {
                    return this.someNullableField;
                }
                set {
                    this.someNullableField = value;
                }
            }
            
            /// <remarks/>
            public System.Nullable<System.DateTime> SomeDateTime {
                get {
                    return this.someDateTimeField;
                }
                set {
                    this.someDateTimeField = value;
                }
            }
            
            /// <remarks/>
            public XmlColor MyColor {
                get {
                    return this.myColorField;
                }
                set {
                    this.myColorField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public long Id {
                get {
                    return this.idField;
                }
                set {
                    this.idField = value;
                }
            }
        }
        
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("XsdToClassTest", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=false)]
        public enum SomeEnum {
            
            /// <remarks/>
            DefaultValue,
            
            /// <remarks/>
            FirstValue,
            
            /// <remarks/>
            SecondValue,
            
            /// <remarks/>
            ThirdValue,
        }
        
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("XsdToClassTest", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=true)]
        public partial class XmlColor {
            
            private string webField;
            
            private byte alphaField;
            
            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Web {
                get {
                    return this.webField;
                }
                set {
                    this.webField = value;
                }
            }
            
            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public byte Alpha {
                get {
                    return this.alphaField;
                }
                set {
                    this.alphaField = value;
                }
            }
        }
        
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("XsdToClassTest", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=true)]
        public partial class RootClass {
            
            private SampleClass[] sampleClassesField;
            
            /// <remarks/>
            public SampleClass[] SampleClasses {
                get {
                    return this.sampleClassesField;
                }
                set {
                    this.sampleClassesField = value;
                }
            }
        }
        
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("XsdToClassTest", "1.0.0.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlRootAttribute(Namespace="", IsNullable=true)]
        public partial class ArrayOfSampleClass {
            
            private SampleClass[] sampleClassField;
            
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("SampleClass", IsNullable=true)]
            public SampleClass[] SampleClass {
                get {
                    return this.sampleClassField;
                }
                set {
                    this.sampleClassField = value;
                }
            }
        }
    }
