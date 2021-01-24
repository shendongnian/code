    class UserInvolvement
	{
		public int UserId;
		public string Name;
		public string OtherInfo;
	
		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			UserInvolvement p = obj as UserInvolvement;
			if ((System.Object)p == null)
			{
				return false;
			}
			return (UserId == p.UserId) && (Name == p.Name) && (OtherInfo == p.OtherInfo);
		}
		public override string ToString()
		{
			return $"{UserId} - {Name} - {OtherInfo}";
		}
	}
