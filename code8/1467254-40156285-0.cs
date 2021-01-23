    public class SomeClass
    {
        private readonly IDictionary<CompositeIntegralTriplet, object> _dictionary = new Dictionary<CompositeIntegralTriplet, object>();
    }
    public sealed class CompositeIntegralTriplet : IEquatable<CompositeIntegralTriplet>
    {
        public CompositeIntegralTriplet(int first, int second, int third)
        {
            First = first;
            Second = second;
            Third = third;
        }
        public int First { get; }
        public int Second { get; }
        public int Third { get; }
        public override bool Equals(object other)
        {
            var otherAsTriplet = other as CompositeIntegralTriplet;
            return Equals(otherAsTriplet);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = First;
                hashCode = (hashCode*397) ^ Second;
                hashCode = (hashCode*397) ^ Third;
                return hashCode;
            }
        }
        public bool Equals(CompositeIntegralTriplet other) => other != null && First == other.First && Second == other.Second && Third == other.Third;
    }
