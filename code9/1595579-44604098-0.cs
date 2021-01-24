    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Ontology
    {
        private OntologyClassAssertion classAssertionField;
        private OntologyDataPropertyAssertion[] dataPropertyAssertionField;
        /// <remarks/>
        public OntologyClassAssertion ClassAssertion
        {
            get
            {
                return this.classAssertionField;
            }
            set
            {
                this.classAssertionField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("DataPropertyAssertion")]
        public OntologyDataPropertyAssertion[] DataPropertyAssertion
        {
            get
            {
                return this.dataPropertyAssertionField;
            }
            set
            {
                this.dataPropertyAssertionField = value;
            }
        }
    }
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OntologyClassAssertion
    {
        private OntologyClassAssertionClass classField;
        private OntologyClassAssertionNamedIndividual namedIndividualField;
        /// <remarks/>
        public OntologyClassAssertionClass Class
        {
            get
            {
                return this.classField;
            }
            set
            {
                this.classField = value;
            }
        }
        /// <remarks/>
        public OntologyClassAssertionNamedIndividual NamedIndividual
        {
            get
            {
                return this.namedIndividualField;
            }
            set
            {
                this.namedIndividualField = value;
            }
        }
    }
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OntologyClassAssertionClass
    {
        private string iRIField;
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string IRI
        {
            get
            {
                return this.iRIField;
            }
            set
            {
                this.iRIField = value;
            }
        }
    }
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OntologyClassAssertionNamedIndividual
    {
        private string iRIField;
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string IRI
        {
            get
            {
                return this.iRIField;
            }
            set
            {
                this.iRIField = value;
            }
        }
    }
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OntologyDataPropertyAssertion
    {
        private OntologyDataPropertyAssertionDataProperty dataPropertyField;
        private OntologyDataPropertyAssertionNamedIndividual namedIndividualField;
        private OntologyDataPropertyAssertionLiteral literalField;
        /// <remarks/>
        public OntologyDataPropertyAssertionDataProperty DataProperty
        {
            get
            {
                return this.dataPropertyField;
            }
            set
            {
                this.dataPropertyField = value;
            }
        }
        /// <remarks/>
        public OntologyDataPropertyAssertionNamedIndividual NamedIndividual
        {
            get
            {
                return this.namedIndividualField;
            }
            set
            {
                this.namedIndividualField = value;
            }
        }
        /// <remarks/>
        public OntologyDataPropertyAssertionLiteral Literal
        {
            get
            {
                return this.literalField;
            }
            set
            {
                this.literalField = value;
            }
        }
    }
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OntologyDataPropertyAssertionDataProperty
    {
        private string iRIField;
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string IRI
        {
            get
            {
                return this.iRIField;
            }
            set
            {
                this.iRIField = value;
            }
        }
    }
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OntologyDataPropertyAssertionNamedIndividual
    {
        private string iRIField;
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string IRI
        {
            get
            {
                return this.iRIField;
            }
            set
            {
                this.iRIField = value;
            }
        }
    }
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OntologyDataPropertyAssertionLiteral
    {
        private string datatypeIRIField;
        private string valueField;
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string datatypeIRI
        {
            get
            {
                return this.datatypeIRIField;
            }
            set
            {
                this.datatypeIRIField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
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
