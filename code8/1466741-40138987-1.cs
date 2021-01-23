    public class MyComparer : IEqualityComparer<Mine>
	{
		public bool Equals(Mine x, Mine y)
		{
            if (x == null && y == null) return true;            
            if (x == null || y == null) return false;
			return x.Name == y.Name && x.Id == y.Id;
		}
		public int GetHashCode(Mine obj)
		{
			return obj.Name.GetHashCode() ^ obj.Id.GetHashCode();
		}
	}
