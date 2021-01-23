    public class varString
    {
        [XmlText]
        public string Value;
        public string KeyWord;
        public static implicit operator string(varString v)
        {
            return v == null ? null : (string)v.Value;
        }
    }
