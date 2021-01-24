    public struct RoundedDecimal
    {
        public static int Precision { get; private set; }
        public static Decimal AbsoluteValue(
            RoundedDecimal d) => Math.Abs(d.value);
        //same with ceiling, floor, etc.
        private readonly decimal value;
        public RoundedDecimal(decimal d)
        {
            value = Decimal.Round(d, Precision);
        }
        public static void SetPrecision(int precision)
        {
            Precision = precision; /*omitted argument validation*/ }
         public static implicit operator Decimal(
             RoundedDecimal d) => d.value;
        public static explicit operator RoundedDecimal(
            decimal d) => new RoundedDecimal(d);
        public static RoundedDecimal operator +(
            RoundedDecimal left, RoundedDecimal right) =>
               new RoundedDecimal(left.value + right.value);
        //etc.
    }
