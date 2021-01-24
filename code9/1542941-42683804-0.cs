    using System.Globalization;
    using System;
    
    public static class ExtensionMethod
    {
        public static string formatStringWithDot(this string stringToFormat)
        {
            string convertResult = "";
            int tempInt;
            if (Int32.TryParse(stringToFormat, out tempInt))
            {
                convertResult = tempInt.ToString("N0", new NumberFormatInfo()
                {
                    NumberGroupSizes = new[] { 3 },
                    NumberGroupSeparator = "."
                });
            }
            return convertResult;
        }
    
        public static string formatStringWithDot(this int intToFormat)
        {
            string convertResult = "";
    
            convertResult = intToFormat.ToString("N0", new NumberFormatInfo()
            {
                NumberGroupSizes = new[] { 3 },
                NumberGroupSeparator = "."
            });
            return convertResult;
        }
    }
