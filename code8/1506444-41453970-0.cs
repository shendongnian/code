    public class NumberFormatter : IFormatProvider, ICustomFormatter
        {
            //TODO: Get your own NumberFormatInfo from CurrentCulture instead of this.
            private static readonly NumberFormatInfo NumberFormatInfo = CultureInfo.CreateSpecificCulture("en-US").NumberFormat;
            public object GetFormat(Type formatType)
            {
                if (formatType != typeof(ICustomFormatter))
                {
                    throw new InvalidOperationException("Invalid Format");
                }
                return this;
            }
            public string Format(string format, object arg, IFormatProvider formatProvider)
            {
                var supportedTypes = new Type[] { typeof(decimal), typeof(double), typeof(int), typeof(float) };
                if (!supportedTypes.Contains(arg.GetType()))
                {
                    return null;
                }
                if (format.ToUpper() != "C")
                {
                    return null;
                }
                var result = arg.ToString();
                var isFraction = result.IndexOf(".", System.StringComparison.Ordinal) > 0;
                if (isFraction)
                {
                    result = RemoveTrailingZero(result);
                    var numberOfDigits = result.Substring(result.IndexOf(".", System.StringComparison.Ordinal) + 1).Length;
                    if (numberOfDigits < 5)
                    {
                        NumberFormatInfo.CurrencyDecimalDigits = numberOfDigits;
                        NumberFormatInfo.NumberDecimalDigits = numberOfDigits;
                    }
                    else
                    {
                        NumberFormatInfo.CurrencyDecimalDigits = 5;
                        NumberFormatInfo.NumberDecimalDigits = 5;
                    }
                }
                return Convert.ToDecimal(result).ToString("C", NumberFormatInfo);
            }
            private string RemoveTrailingZero(string number)
            {
                var lastIndexOfZero = number.LastIndexOf("0", System.StringComparison.Ordinal);
                if (lastIndexOfZero == number.Length - 1)
                {
                    number = number.Remove(lastIndexOfZero);
                    return RemoveTrailingZero(number);
                }
                else
                {
                    return number;
                }
            }
        }
