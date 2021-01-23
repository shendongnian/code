    public class MyComparer : IEqualityComparer<Mine>
	{
		public bool Equals(Mine x, Mine y)
		{
			return x.Name == y.Name && x.Id == y.Id;
		}
		public int GetHashCode(Mine obj)
		{
			return obj.Name.GetHashCode() ^ obj.Id.GetHashCode();
		}
	}
