    public class ArbDecimal
    {
        BigInteger value;
        BigInteger exponent;
        public override string ToString()
        {
             return (BigInteger.Pow(value,exponent)).ToString());
        }
    }
