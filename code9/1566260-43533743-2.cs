    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    
    namespace Rextester
    {
    
        public class FileSizeConverter
        {
            private static System.Globalization.NumberFormatInfo numberFormat;
            private static Dictionary<string, long> knownUnits;
    
            static FileSizeConverter()
            {
                /*  
                
                // base2/binary "computer" units
    
                knownUnits = new Dictionary<string, long>
                { 
                    { "", 1L },                                 // no unit is same as unit B(yte)
                    { "B", 1L },
                    { "KB", 1024L },
                    { "MB", 1024L * 1024L},
                    { "GB", 1024L * 1024L * 1024L},
                    { "TB", 1024L * 1024L * 1024L * 1024L}
                    // fill rest as needed
                };
                
                */
    
                // decimal "contraction" units 
    
                knownUnits = new Dictionary<string, long>
                {
                    { "", 1L },
                    { "M", 1000L * 1000L }, // million
                    { "B", 1000L * 1000L * 1000L } // billion (usa)
                    // fill rest as needed
                };
    
                numberFormat = System.Globalization.CultureInfo.CurrentCulture.NumberFormat;
            }
    
            public decimal Parse(string value)
            {
                // ignore spaces around the actual value
                value = value.Trim();
    
                string unit = ExtractUnit(value);
                string sizeAsString = value.Substring(0, value.Length - unit.Length).Trim();  // trim spaces
    
                long multiplicator = MultiplicatorForUnit(unit);
                decimal size;
    
                if (!decimal.TryParse(sizeAsString, System.Globalization.NumberStyles.Number, numberFormat, out size))
                    throw new ArgumentException("illegal number", "value");
    
                return multiplicator * size;
            }
    
            private bool IsDigit(char value)
            {
                // we don't want to use char.IsDigit since it would accept esoterical unicode digits
                if (value < '0') return false;
                if (value > '9') return false;
    
                return true;
            }
    
            private string ExtractUnit(string sizeWithUnit)
            {
                // start right, end at the first digit
                int lastChar = sizeWithUnit.Length - 1;
                int unitLength = 0;
    
                while (unitLength <= lastChar
                    && sizeWithUnit[lastChar - unitLength] != ' '       // stop when a space
                    && !IsDigit(sizeWithUnit[lastChar - unitLength]))   // or digit is found
                {
                    unitLength++;
                }
    
                return sizeWithUnit.Substring(sizeWithUnit.Length - unitLength).ToUpperInvariant();
            }
    
            private long MultiplicatorForUnit(string unit)
            {
                unit = unit.ToUpperInvariant();
    
                if (!knownUnits.ContainsKey(unit))
                    throw new ArgumentException("illegal or unknown unit", "unit");
    
                return knownUnits[unit];
            }
        }
    
        public class Program
        {
            public static void Main(string[] paramList)
            {
                var converter = new FileSizeConverter();
                Console.WriteLine(converter.Parse("1.25M"));
                Console.WriteLine(converter.Parse("10M"));
                Console.WriteLine(converter.Parse("10.5M"));
                Console.WriteLine(converter.Parse("47.6B"));
            }
        }
    }
