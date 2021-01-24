	public class CaseInsensitiveMyTypeEqualityComparer : IEqualityComparer<MyType>
	{
	    public bool Equals(MyType x, MyType y)
		{
		    if ((object)x == (object)y)
			{
			    return true;
			}
			if ((object)x == null | (object)y == null)
			{
			    return false;
			}
			return x.count == y.count && string.Equals(x.name, y.name, StringComparison.OrdinalIgnoreCase);
		}
		
		public int GetHashCode(MyType obj)
		{
		    if (obj == null)
			{
			    return 0;
			}
		    return StringComparer.OrdinalIgnoreCase.GetHashCode(obj.name) ^ obj.count;
		}
	}
