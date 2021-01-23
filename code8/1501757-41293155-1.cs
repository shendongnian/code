    [XmlIgnore]
    public Shipping ShippingOption { get; set; }
    [XmlAttribute(AttributeName = "shipper")]
    public string ShippingOptionString
    {
        get { return FormatEnum<Shipping>ShippingOption); }
        set { ShippingOption = ParseEnum<Shipping>(value); }
    }
