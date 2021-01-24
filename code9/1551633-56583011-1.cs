    public partial class ListViewRecord {
      
        private ListViewRecordColumn[] columnsField;
        
        /// ** delete this member variable **
        private int dummyField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("columns")]
        public ListViewRecordColumn[] columns {
            get {
                return this.columnsField;
            }
            set {
                this.columnsField = value;
            }
        }
        
        /// ** delete this property **
        public int dummy {
            get {
                return this.dummyField;
            }
            set {
                this.dummyField = value;
            }
        }
    }
