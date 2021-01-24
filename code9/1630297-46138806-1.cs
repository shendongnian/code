    public class XmlWriterAdapter : XmlWriter
    {
        XmlWriter _adaptedWriter;
        public XmlWriterAdapter():base(){}
        public XmlWriter AdaptedWriter 
        {
            get
            {
                return _adaptedWriter;
            } 
            set
            {
                this._adaptedWriter = value;
            }
        }
        public override WriteState WriteState { get{return _adaptedWriter.WriteState;} }
        public override void Flush()
        {
            _adaptedWriter.Flush();
        }
        public override string LookupPrefix(string ns)
        {
            return _adaptedWriter.LookupPrefix(ns);
        }
    }
