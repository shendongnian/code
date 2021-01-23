    class Program
    {
        static void Main(string[] args)
        {
            double number = 123.1234567890129;
            var result = string.Format(new CustomFormatProvider(15), "{0}", number);
        }
    }
    public class CustomFormatProvider : IFormatProvider, ICustomFormatter
    {
        private readonly int _numberOfDigits;
        public CustomFormatProvider(int numberOfDigits)
        {
            _numberOfDigits = numberOfDigits;
        }
        public object GetFormat(Type formatType) => formatType == typeof(ICustomFormatter) ? this : null;
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (!Equals(formatProvider))
                return null;
            if (!(arg is double))
            {
                return null;
            }
            var input = ((double)arg).ToString("R");
            return input.Length > _numberOfDigits + 1 ? input.Substring(0, _numberOfDigits + 1) : input; // +1 because of dot
        }
