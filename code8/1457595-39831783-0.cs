    public class MyProtocol : SoapHttpClientProtocol {
        protected override WebRequest GetWebRequest(Uri uri) {
            var request = (HttpWebRequest) base.GetWebRequest(uri);
            request.ServicePoint.BindIPEndPointDelegate += (servicePoint, remoteEndPoint, retryCount) => {
                return new IPEndPoint(IPAddress.Parse("your external id here"), 0);
            };
            return request;
        }
    }
