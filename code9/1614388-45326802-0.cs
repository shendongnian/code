    public class StringWriterWithEncoding : StringWriter
    {
        Encoding myEncoding;
        public override Encoding Encoding
        {
            get
            {
                return myEncoding;
            }
        }
        public StringWriterWithEncoding(Encoding encoding) : base()
        {
            myEncoding = encoding;
        }
        public StringWriterWithEncoding(Encoding encoding) : base(CultureInfo.CurrentCulture)
        {
            myEncoding = encoding;
        }
        public StringWriterWithEncoding(StringBuilder sb, Encoding encoding) : base(sb, CultureInfo.CurrentCulture)
        {
            myEncoding = encoding;
        }
    }
