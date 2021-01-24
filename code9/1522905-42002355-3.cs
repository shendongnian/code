    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class IncidentsIncident
    {
        private byte incidentNumberField;
        private byte summaryField;
        private byte reason1Field;
        private byte reason2Field;
        private byte reason3Field;
        /// <remarks/>
        public byte IncidentNumber
        {
            get
            {
                return this.incidentNumberField;
            }
            set
            {
                this.incidentNumberField = value;
            }
        }
        /// <remarks/>
        public byte Summary
        {
            get
            {
                return this.summaryField;
            }
            set
            {
                this.summaryField = value;
            }
        }
        /// <remarks/>
        public byte Reason1
        {
            get
            {
                return this.reason1Field;
            }
            set
            {
                this.reason1Field = value;
            }
        }
        /// <remarks/>
        public byte Reason2
        {
            get
            {
                return this.reason2Field;
            }
            set
            {
                this.reason2Field = value;
            }
        }
        /// <remarks/>
        public byte Reason3
        {
            get
            {
                return this.reason3Field;
            }
            set
            {
                this.reason3Field = value;
            }
        }
    }
