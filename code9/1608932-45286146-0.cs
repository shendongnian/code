    [TestClass]
    public class SOAP_UnitTests {
        private HttpMethod method;
        private string uri;
        private string action;
        [TestMethod]
        public void _Add_SOAP_Auth_Header_Details_With_HttpRequestMessage() {
            string username = "TheUserName";
            string password = "ThePassword";
            var xml = ConstructSoapEnvelope();
            var doc = XDocument.Parse(xml);
            var authHeader = doc.Descendants("{http://www.test.com/testing/Security}AuthenticationHeader").FirstOrDefault();
            if (authHeader != null) {
                authHeader.Element(authHeader.GetDefaultNamespace() + "UserName").Value = username;
                authHeader.Element(authHeader.GetDefaultNamespace() + "Password").Value = password;
            }
            string envelope = doc.ToString();
            var request = CreateRequest(method, uri, action, doc);
            request.Content = new StringContent(envelope, Encoding.UTF8, "text/xml");
            //request is now ready to be sent via HttpClient
            //client.SendAsync(request);
        }
        private static HttpRequestMessage CreateRequest(HttpMethod method, string url, string action, XDocument soapEnvelopeXml) {
            var request = new HttpRequestMessage(method: method, requestUri: url);
            request.Headers.Add("SOAPAction", action);
            request.Headers.Add("ContentType", "text/xml;charset=\"utf-8\"");
            request.Headers.Add("Accept", "text/xml");
            request.Content = new StringContent(soapEnvelopeXml.ToString(), Encoding.UTF8, "text/xml"); ;
            return request;
        }
        private string ConstructSoapEnvelope() {
            var message = @"<?xml version='1.0' encoding='utf-8'?>
    <soap:Envelope xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema' xmlns:soap='http://schemas.xmlsoap.org/soap/envelope/'>
      <soap:Header>
        <AuthenticationHeader xmlns='http://www.test.com/testing/Security'>
          <UserName>string</UserName>
          <Password>string</Password>
        </AuthenticationHeader>
      </soap:Header>
      <soap:Body>
        <GetMeSomething xmlns='http://www.test.com/testing/WorkFileCatalog'>
          <Param1>string</Param1>
          <Param2>string</Param2>
          <XMLRetMess>string</XMLRetMess>
        </GetMeSomething>
      </soap:Body>
    </soap:Envelope>
    ";
            return message;
        }
    }
