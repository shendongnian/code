    public class SqlFormatter : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            return arg == null ? "null" : string.Format("'{0}'", arg);
        }
    }
