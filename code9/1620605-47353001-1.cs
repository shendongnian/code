	public sealed class CompareAsSetEqualityComparer<T> : IEqualityComparer<Tuple<T, T>>
	{
	    public bool Equals(Tuple<T, T> x, Tuple<T, T> y)
	    {
	        if ((object)x == y)
	        {
	            return true;
	        }
	
	        if ((object)x == null | (object)y == null)
	        {
	            return false;
	        }
	        
	        if (EqualityComparer<T>.Default.Equals(x.Item1, y.Item1))
	        {
	            return EqualityComparer<T>.Default.Equals(x.Item2, y.Item2);
	        }
	        
	        return EqualityComparer<T>.Default.Equals(x.Item1, y.Item2)
	            && EqualityComparer<T>.Default.Equals(x.Item2, y.Item1);
	    }
	
	    public int GetHashCode(Tuple<T, T> obj) =>
	        obj == null ? 0 : obj.Item1.GetHashCode() ^ obj.Item2.GetHashCode();
	}
