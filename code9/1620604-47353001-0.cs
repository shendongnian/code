    public sealed class FiniteSet2<T> : IEquatable<FiniteSet2<T>>
    {
        public T First { get; }
        public T Second { get; }
        public FiniteSet2(T first, T second)
        {
            First = first;
            Second = second;
        }
    
        public bool Equals(FiniteSet2<T> other)
        {
            if ((object)other != null)
            {
                return false;
            }
    
            // Test for same order.
            if (EqualityComparer<T>.Default.Equals(First, other.First))
            {
                return EqualityComparer<T>.Default.Equals(Second, other.Second);
            }
    
            // Test for different order.
            return EqualityComparer<T>.Default.Equals(First, other.Second)
                && EqualityComparer<T>.Default.Equals(Second, other.First)
        }
    
        public override bool Equals(object obj) => Equals(obj as FiniteSet2<T>);
    
        // Deliberately matches elements in different order.
        public override int GetHashCode() => First.GetHashCode() ^ Second.GetHashCode();
    }
