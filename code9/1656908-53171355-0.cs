    public class CustomMessageHeader : MessageHeader
    {
        private string _Name;
        private string _NameSpace;
        private object _Value;
        private bool _IsReference;
        private string _WsAddressElement;
        private const string _WsAddressNamespace = "http://www.w3.org/2005/08/addressing";
        public CustomMessageHeader(string name, string nameSpace, bool isReference, object value, string wsAdressElement = null)
        {
            _Name = name;
            _NameSpace = nameSpace;
            _Value = value;
            _IsReference = isReference;
            _WsAddressElement = wsAdressElement;
        }
        public override string Name
        {
            get
            {
                return _Name;
            }
        }
        public override string Namespace
        {
            get
            {
                return _NameSpace;
            }
        }
        protected override void OnWriteStartHeader(XmlDictionaryWriter writer, MessageVersion messageVersion)
        {
            if (!string.IsNullOrEmpty(_WsAddressElement))
                writer.WriteStartElement(_WsAddressElement, _WsAddressNamespace);
            if (_IsReference)
                writer.WriteStartElement("ReferenceProperties", _WsAddressNamespace);
            writer.WriteStartElement(_Name, _NameSpace);
        }
        protected override void OnWriteHeaderContents(XmlDictionaryWriter writer, MessageVersion messageVersion)
        {          
            writer.WriteValue(_Value);            
            if (_IsReference)
                writer.WriteEndElement();
            if (!string.IsNullOrEmpty(_WsAddressElement))
                writer.WriteEndElement();
        }
    }
    
