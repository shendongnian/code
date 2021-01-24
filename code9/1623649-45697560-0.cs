    [DelimitedRecord(",")]
	public class Users : IEquatable<Users>
	{
		public string LogonName;
		public string DisplayName;
		public string FirstName;
		public string LastName;
		public string SamAccountName;
		public string Password;
		public string Identity;
		public override bool Equals(object obj)
		{
			return Equals(obj as Users);
		}
		public bool Equals(Users other)
		{
			return other != null &&
				   LogonName == other.LogonName &&
				   DisplayName == other.DisplayName &&
				   FirstName == other.FirstName &&
				   LastName == other.LastName &&
				   SamAccountName == other.SamAccountName &&
				   Password == other.Password &&
				   Identity == other.Identity;
		}
		public override int GetHashCode()
		{
			var hashCode = -1297710060;
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LogonName);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(DisplayName);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FirstName);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(LastName);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(SamAccountName);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Password);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Identity);
			return hashCode;
		}
	}
