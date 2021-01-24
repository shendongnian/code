csharp
public class TestWebEnvironment : IDisposable
{
	private TestServer Server { get; }
	private CookieContainer CookieContainer { get; }
	
	public TestWebEnvironment()
	{
		var builder = new WebHostBuilder()
			.UseEnvironment("Test")
			.UseStartup<TestWebStartup>();
		Server = new TestServer(builder);
		CookieContainer = new CookieContainer();
	}
	private RequestBuilder BuildRequest(string url)
	{
		var uri = new Uri(Server.BaseAddress, url);
		var builder = Server.CreateRequest(url);
		var cookieHeader = CookieContainer.GetCookieHeader(uri);
		if (!string.IsNullOrWhiteSpace(cookieHeader))
		{
			builder.AddHeader(HeaderNames.Cookie, cookieHeader);
		}
		return builder;
	}
	private void UpdateCookies(string url, HttpResponseMessage response)
	{
		if (response.Headers.Contains(HeaderNames.SetCookie))
		{
			var uri = new Uri(Server.BaseAddress, url);
			var cookies = response.Headers.GetValues(HeaderNames.SetCookie);
			foreach (var cookie in cookies)
			{
				CookieContainer.SetCookies(uri, cookie);
			}
		}
	}
	public async Task<string> GetAsync(string url)
	{
		using (var response = await BuildRequest(url).GetAsync())
		{
			UpdateCookies(url, response);
			return await response.Content.ReadAsStringAsync();
		}
	}
	public async Task<string> PostAsync(string url, HttpContent content)
	{
		var builder = BuildRequest(url);
		builder.And(request => request.Content = content);
		using (var response = await builder.PostAsync())
		{
			UpdateCookies(url, response);
			return await response.Content.ReadAsStringAsync();
		}
	}
	public void Dispose()
	{
		Server.Dispose();
	}
}
