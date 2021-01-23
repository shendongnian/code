    public struct IsoDecimal
    {
        private NumberFormatInfo numberFormat { get; set; }
        private decimal value { get; set; }
    
        public IsoDecimal(string strValue)
        {
            string strNumber = Regex.Match(strValue, @"[\d.\-,]+").Value;
            string code = Regex.Match(strValue, @"[A-Z]+").Value;
            
            numberFormat = new NumberFormatInfo();
            numberFormat.NegativeSign = "-";
            numberFormat.CurrencyDecimalSeparator = ".";
            numberFormat.CurrencyGroupSeparator = ",";
            numberFormat.CurrencySymbol = code;
            
            value = Decimal.Parse(strNumber);
        }
        
        public static implicit operator decimal(IsoDecimal isoDecimal)
        {
            return isoDecimal.value;
        }
        
        public override string ToString()
        {
            return ToString("C");
        }
        
        public string ToString(string format)
        {
            return value.ToString(format, numberFormat);
        }
    }
