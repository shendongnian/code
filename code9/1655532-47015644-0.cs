    public interface IHttpContext
    {
        string Url { get; }
    }
    public class HttpContextProvider : IHttpContext
    {
        public string Url => HttpContext.Current.Request.Url.ToString();
    }
    public class MockedHttpContextProvider : IHttpContext
    {
        public string Url => "https://google.com";
    }
