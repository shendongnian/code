    public class ArbDecimal
    {
        BigInteger value;
        int exponent;
        public override string ToString()
        {
             StringBuilder sb = new StringBuilder();
             int place;
             foreach (char digit in value.ToString())
             {
                 if (place++ == value.ToString().Length - exponent)
                 {
                     sb.Append('.');
                 }
                 sb.Append(digit);
             }
             return sb.ToString();
        }
    }
