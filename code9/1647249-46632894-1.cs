    public class Fraction<T> where T : struct, IConvertible {
        public T Numerator { get; set; }
        public T Denominator { get; set; }
        public double GetValue() {
            return Numerator.ToDouble(null) / Denominator.ToDouble(null);
            // or return Numerator.ToInt64(null) / (double) Denominator.ToInt64(null); etc
        }
    }
