    // public exposed interfaces
	public interface IUser
	{
		int ReadOnlyInteger { get; }
		bool WriteOnlyBool { set; }
		DateTime ReadWriteDateTime { get; set; }
	}
    // public exposed interface
	public interface ISecuredUserService
	{
		bool TryChangePassword(IUser user, string value);
	}
