    // public exposed interfaces
	public interface IUser
	{
		int ReadOnlyInteger { get; }
	}
    // public exposed interface
	public interface ISecuredUserService
	{
		bool TryChangePassword(IUser user, string value);
	}
