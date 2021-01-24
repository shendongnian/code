    namespace USS_EDIv2.Models
    {
    public class Orders
    {
    }
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class Order
    {
        private uint salesOrderNumberField;
        private uint purchaseOrderNumberField;
        private ushort branchPlantField;
        private OrderShipTo shipToField;
        private byte quantityField;
        private string uOMField;
        private OrderDetail[] detailField;
        /// <remarks/>
        public uint SalesOrderNumber
        {
            get
            {
                return this.salesOrderNumberField;
            }
            set
            {
                this.salesOrderNumberField = value;
            }
        }
        /// <remarks/>
        public uint PurchaseOrderNumber
        {
            get
            {
                return this.purchaseOrderNumberField;
            }
            set
            {
                this.purchaseOrderNumberField = value;
            }
        }
        /// <remarks/>
        public ushort BranchPlant
        {
            get
            {
                return this.branchPlantField;
            }
            set
            {
                this.branchPlantField = value;
            }
        }
        /// <remarks/>
        public OrderShipTo ShipTo
        {
            get
            {
                return this.shipToField;
            }
            set
            {
                this.shipToField = value;
            }
        }
        /// <remarks/>
        public byte Quantity
        {
            get
            {
                return this.quantityField;
            }
            set
            {
                this.quantityField = value;
            }
        }
        /// <remarks/>
        public string UOM
        {
            get
            {
                return this.uOMField;
            }
            set
            {
                this.uOMField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Detail")]
        public OrderDetail[] Detail
        {
            get
            {
                return this.detailField;
            }
            set
            {
                this.detailField = value;
            }
        }
    }
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OrderShipTo
    {
        private string line1Field;
        private uint postalCodeField;
        private string cityField;
        private string stateField;
        private string countryCodeField;
        private string idField;
        /// <remarks/>
        public string Line1
        {
            get
            {
                return this.line1Field;
            }
            set
            {
                this.line1Field = value;
            }
        }
        /// <remarks/>
        public uint PostalCode
        {
            get
            {
                return this.postalCodeField;
            }
            set
            {
                this.postalCodeField = value;
            }
        }
        /// <remarks/>
        public string City
        {
            get
            {
                return this.cityField;
            }
            set
            {
                this.cityField = value;
            }
        }
        /// <remarks/>
        public string State
        {
            get
            {
                return this.stateField;
            }
            set
            {
                this.stateField = value;
            }
        }
        /// <remarks/>
        public string CountryCode
        {
            get
            {
                return this.countryCodeField;
            }
            set
            {
                this.countryCodeField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string id
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
    }
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class OrderDetail
    {
        private decimal lineNumberField;
        private string gradeItemField;
        private decimal quantityField;
        private string uOMField;
        private System.DateTime requestDateField;
        private string statusField;
        private System.DateTime createdField;
        private string actionField;
        /// <remarks/>
        public decimal LineNumber
        {
            get
            {
                return this.lineNumberField;
            }
            set
            {
                this.lineNumberField = value;
            }
        }
        /// <remarks/>
        public string GradeItem
        {
            get
            {
                return this.gradeItemField;
            }
            set
            {
                this.gradeItemField = value;
            }
        }
        /// <remarks/>
        public decimal Quantity
        {
            get
            {
                return this.quantityField;
            }
            set
            {
                this.quantityField = value;
            }
        }
        /// <remarks/>
        public string UOM
        {
            get
            {
                return this.uOMField;
            }
            set
            {
                this.uOMField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "date")]
        public System.DateTime RequestDate
        {
            get
            {
                return this.requestDateField;
            }
            set
            {
                this.requestDateField = value;
            }
        }
        /// <remarks/>
        public string Status
        {
            get
            {
                return this.statusField;
            }
            set
            {
                this.statusField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime created
        {
            get
            {
                return this.createdField;
            }
            set
            {
                this.createdField = value;
            }
        }
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string action
        {
            get
            {
                return this.actionField;
            }
            set
            {
                this.actionField = value;
            }
        }
    }
