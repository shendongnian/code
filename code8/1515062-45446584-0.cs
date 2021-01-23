    public class DefaultEqualityComparer<T> : IEqualityComparer<T>
    {
      readonly EqualityComparer<T> _comparer = System.Collections.Generic.EqualityComparer<T>.Default;
      public bool Equals(T x, T y) => _comparer.Equals(x, y);
      public int GetHashCode(T obj) => _comparer.GetHashCode(obj);
    }
