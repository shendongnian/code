    public interface IRange<T> : IEquatable<T> where T : IComparable {
        T Maximum { get; }
        T Minimum { get; }
    }
    public sealed class Range<T> : IRange<T>
        where T : IComparable {
        public Range(T minimum, T maximum) {
            Minimum = minimum;
            Maximum = maximum;
        }
        public T Maximum { get; private set; }
        public T Minimum { get; private set; }
        public override string ToString() {
            return string.Format("{{{0} - {1}}}", Minimum, Maximum);
        }
        public override int GetHashCode() {
            return ToString().GetHashCode();
        }
        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) {
                return false;
            }
            return obj is Range<T> && Equals((Range<T>)obj);
        }
        public bool Equals(T other) {
            return object.Equals(this.ToString(), other.ToString());
        }
    }
