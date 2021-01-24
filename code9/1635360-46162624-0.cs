    [XmlIgnore]
    public DateTime? Date
    {
        get
        {
            DateTime dt;
            if(DateTime.TryParse(SerialDate, out dt))
            {
                return dt;
            }
            return null;
        }
        set
        {
            SerialDate = value == null ? (string)null : value.Value.ToString("yyyy-MM-ddTHH:mm:ss");
        }
    }
    [System.Xml.Serialization.XmlElement("Date", Namespace = "http://webservices.mycompany.com/Framework/17.2.0")]
    public string SerialDate { get; set; }
