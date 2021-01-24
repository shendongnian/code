    public class TestController : ApiController
    {
        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent("Hello from OWIN!")
            };
        }
        public HttpResponseMessage Get(int id)
        {
            var Thumbprint = Request.GetClientCertificate().Thumbprint.ToString();
            string msg = String.Format("Hello from OWIN (id = {0})", id);
            return new HttpResponseMessage()
            {
                Content = new StringContent(msg)
            };
        }
    }
