    public class CustomDataContractOutputFormatter : XmlDataContractSerializerOutputFormatter
    {
        public CustomDataContractOutputFormatter() : base(){}
        public CustomDataContractOutputFormatter(XmlWriterSettings set) : base(set){}
        public override XmlWriter CreateXmlWriter(TextWriter writer, XmlWriterSettings xmlWriterSettings)
        {
            var bas = base.CreateXmlWriter(writer, xmlWriterSettings);
            var ret = new XmlWriterNoNamespace();
            ret.AdaptedWriter = bas;
            return ret;
        }
    }
