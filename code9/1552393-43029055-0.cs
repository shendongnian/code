    public class Channel : IXmlSerializable
    {
        private string m_Name = string.Empty;
        private DateTime? m_TxTime = null;
    
        public string Name
        {
            get
            {
                return m_Name;
            }
            set
            {
                m_Name = value;
            }
        }
    
        public DateTime? TxTime
        {
            get
            {
                return m_TxTime;
            }
            set
            {
                m_TxTime = value;
            }
        }
    
        private string txtTimeForSerialization
        {
            get
            {
                if (TxTime.HasValue)
                {
                    return TxTime.Value.ToString("o");
                }
                else
                {
                    return null;
                }
            }
        }
    
        public XmlSchema GetSchema()
        {
            return null;
        }
    
        public void ReadXml(XmlReader reader)
        {
            //implement reader if needed...
        }
    
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("name", this.Name);
            writer.WriteAttributeString("txtTime", this.txtTimeForSerialization);
        }
    }
