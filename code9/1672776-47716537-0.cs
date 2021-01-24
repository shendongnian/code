    public class CustomUtf8EncodingProvider : EncodingProvider
    {
        public override Encoding GetEncoding(string name)
        {
            return name == "utf8" ? Encoding.UTF8 : null;
        }
    
        public override Encoding GetEncoding(int codepage)
        {
            return null;
        }
    }
