    class MyFormatter : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(NumberFormatInfo)) {
                return new NumberFormatInfo()
                {
                    // something here
                };
            }
            Console.WriteLine("GetFormat");
            return this;
        }
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            Console.WriteLine("Format");
            return "foo";
        }
    }
