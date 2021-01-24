      [System.Xml.Serialization.XmlIgnore]
            public string gctpMessage {
                get {
                    return this.gctpMessageField;
                }
                set {
                    this.gctpMessageField = value;
                    this.RaisePropertyChanged("gctpMessage");
                }
            }
    
            [System.Xml.Serialization.XmlElementAttribute(Order = 1, ElementName = "gctpMessage")]
            public XmlNode[] CDataContent
            {
                get
                {
                    var dummy = new XmlDocument();
                    return new XmlNode[] { dummy.CreateCDataSection(gctpMessage) };
                }
                set
                {
                    if (value == null)
                    {
                        gctpMessage = null;
                        return;
                    }
    
                    if (value.Length != 1)
                    {
                        throw new InvalidOperationException(
                            String.Format(
                                "Invalid array length {0}", value.Length));
                    }
    
                    gctpMessage = value[0].Value;
                }
            }
