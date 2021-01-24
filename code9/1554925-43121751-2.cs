cs
public class DefaultHttpClientFactory : IHttpClientFactory, IDisposable
{
	private readonly ConcurrentDictionary<string, HttpClient> _httpClients;
	public DefaultHttpClientFactory()
	{
		this._httpClients = new ConcurrentDictionary<string, HttpClient>();
	}
	public HttpClient Create(string endpoint)
	{
		if (this._httpClients.TryGetValue(endpoint, out var client))
		{
			return client;
		}
		client = new HttpClient
		{
			BaseAddress = new Uri(endpoint),
		};
		this._httpClients.TryAdd(endpoint, client);
		return client;
	}
	public void Dispose()
	{
		this.Dispose(true);
		GC.SuppressFinalize(this);
	}
	protected virtual void Dispose(bool disposing)
	{
		foreach (var httpClient in this._httpClients)
		{
			httpClient.Value.Dispose();
		}
	}
}
That said, if you are not particularly happy with the above design. You could abstract away the `HttpClient` dependency behind a service so that the client does not become an implementation detail.
That consumers of the service need not know exactly how the data is retrieved.
