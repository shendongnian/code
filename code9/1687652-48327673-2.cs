	public class MyComparer : IEqualityComparer<LinqTest>
	{
		public bool Equals(LinqTest x, LinqTest y)
		{
			return x.Str1 == y.Str1 || x.Str2 == y.Str2;
		}
		public int GetHashCode(LinqTest obj)
		{
            int hash = 17;
            hash = hash * 31 + obj.Str1.GetHashCode();
            hash = hash * 31 + obj.Str2.GetHashCode();
            return hash;
		}
	}
