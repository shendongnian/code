    [XmlRoot(ElementName = "customer")]
    public class Customer
    {
        bool? isSimpleFormat;
        [XmlIgnore]
        public bool IsSimpleFormat { get { return isSimpleFormat == true; } set { isSimpleFormat = value; } }
        [XmlIgnore]
        bool IsSimpleFormatDefined { get { return isSimpleFormat != null; } }
        [XmlIgnore]
        bool IsComplexPropertySpecified
        {
            get
            {
                return !IsSimpleFormat;
            }
            set
            {
                if (IsSimpleFormatDefined && IsSimpleFormat)
                {
                    throw new InvalidOperationException("Cannot set a complex property on a simple customer");
                }
                IsSimpleFormat = !value;
            }
        }
        [XmlElement(ElementName = "number")]
        public string Number { get; set; }
        [XmlIgnore]
        public bool NumberSpecified { get { return IsComplexPropertySpecified; } set { IsComplexPropertySpecified = value; } }
        [XmlElement(ElementName = "internalId")]
        public string InternalId { get; set; }
        [XmlIgnore]
        public bool InternalIdSpecified { get { return IsComplexPropertySpecified; } set { IsComplexPropertySpecified = value; } }
        [XmlElement(ElementName = "lastModifiedDateTime")]
        public string LastModifiedDateTime { get; set; }
        [XmlIgnore]
        public bool LastModifiedDateTimeSpecified { get { return IsComplexPropertySpecified; } set { IsComplexPropertySpecified = value; } }
        [XmlText]
        public string SimpleNumber
        {
            get 
            {
                return IsSimpleFormat ? Number : null; 
            }
            set
            {
                IsComplexPropertySpecified = false;
                Number = value;
            }
        }
    }
    [XmlRoot(ElementName = "SalesOrder")]
    public class SalesOrder
    {
        [XmlElement(ElementName = "orderType")]
        public string OrderType { get; set; }
        [XmlElement(ElementName = "customer")]
        public Customer Customer { get; set; }
    }
