	public interface IAuthorizedRequest
	{
		SourceCredentials SourceCredentials { get; set; }
		UserCredentials UserCredentials { get; set; }
	}
