    public class XmlWriterNoNamespace : XmlWriterAdapter
    {
        bool _skipAttribute;
        public XmlWriterNoNamespace():base(){}
        public override void WriteEndAttribute()
        {
            if(_skipAttribute)
            {
                _skipAttribute = false;
                return;
            }
            base.WriteEndAttribute();
        }
        public override void WriteStartAttribute(string prefix, string localName, string ns)
        {
            if(prefix.Equals("xmlns"))
            {
                _skipAttribute = true;
                return;
            }
            base.WriteStartAttribute(prefix, localName, ns);
        }
        public override void WriteString(string text)
        {
            if(_skipAttribute)
                return;
            base.WriteString(text);
        }
    } 
