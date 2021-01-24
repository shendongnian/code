    public class ArrayEqualityComparer<T> : IEqualityComparer<T[]>
    {
        public bool Equals(T[] x, T[] y)
        {
            return x.SequenceEqual(y);
        }
                
    
        public int GetHashCode(T[] array)
        {
            int hc = array.Length;
            for (int i = 0; i < array.Length; ++i)
            {
                hc = unchecked(hc * 314159 + array[i].GetHashCode());
            }
            return hc;
        }
    }
