	public sealed class UsersEqualityComparer : IEqualityComparer<Users>
	{
		public bool Equals(Users x, Users y)
		{
			if (ReferenceEquals(x, y)) return true;
			if (ReferenceEquals(x, null)) return false;
			if (ReferenceEquals(y, null)) return false;
			if (x.GetType() != y.GetType()) return false;
			return string.Equals(x.LogonName, y.LogonName) && string.Equals(x.DisplayName, y.DisplayName) &&
			       string.Equals(x.FirstName, y.FirstName) && string.Equals(x.LastName, y.LastName) &&
			       string.Equals(x.SamAccountName, y.SamAccountName) && string.Equals(x.Password, y.Password) &&
			       string.Equals(x.Identity, y.Identity);
		}
		public int GetHashCode(Users obj)
		{
			unchecked
			{
				var hashCode = (obj.LogonName != null ? obj.LogonName.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (obj.DisplayName != null ? obj.DisplayName.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (obj.FirstName != null ? obj.FirstName.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (obj.LastName != null ? obj.LastName.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (obj.SamAccountName != null ? obj.SamAccountName.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (obj.Password != null ? obj.Password.GetHashCode() : 0);
				hashCode = (hashCode * 397) ^ (obj.Identity != null ? obj.Identity.GetHashCode() : 0);
				return hashCode;
			}
		}
	}
