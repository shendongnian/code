    public class MyProxy : IWebProxy {
	public MyProxy() {	credentials = new NetworkCredential( user, password ); }
	private NetworkCredential credentials;
	public ICredentials Credentials
	{
		get = > credentials;
		set = > throw new NotImplementedException();
	}
	private Uri proxyUri;
	public Uri GetProxy( Uri destination )
	{
		return proxyUri; // your proxy Uri
	}
	public bool IsBypassed( Uri host )
	{
		return false;
	}
	private const string user = "yourusername";
	private const string password = "password";}
