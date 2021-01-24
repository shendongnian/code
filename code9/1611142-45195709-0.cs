    public class DefaultController : ApiController {
        static readonly HttpClient httpClient = new HttpClient();
        [HttpGet]
        public async Task ProjectName() {
            var _url = "http://cmf-sharepoint/ims/Processes/_vti_bin/lists.asmx";
            var _action = "http://schemas.microsoft.com/sharepoint/soap/GetListItems";
                
            var soapEnvelopeXml = CreateSoapEnvelope();
            var request = CreateRequest(_url, _action, soapEnvelopeXml);
                
            string soapResult;            
            using (var response = await httpClient.SendAsync(request)) {
                soapResult = await response.Content.ReadAsStringAsync();
                Console.Write(soapResult);
            }
        }
        private static HttpRequestMessage CreateRequest(string url, string action, XmlDocument soapEnvelopeXml) {
            var request = new HttpRequestMessage(method: HttpMethod.Post, requestUri: url);
            request.Headers.Add("SOAPAction", action);
            request.Headers.Add("ContentType", "text/xml;charset=\"utf-8\"");
            request.Headers.Add("Accept", "text/xml");
            request.Content = new StringContent(soapEnvelopeXml.ToString(), Encoding.UTF8, "text/xml"); ;
            return request;
        }
        private static XmlDocument CreateSoapEnvelope() {
            XmlDocument soapEnvelop = new XmlDocument();
            soapEnvelop.LoadXml(@"<?xml version='1.0' encoding='utf-8'?><soap:Envelope xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema' xmlns:soap='http://schemas.xmlsoap.org/soap/envelope/'><soap:Body>'<GetListItems xmlns='http://schemas.microsoft.com/sharepoint/soap/'><listName>8e82569a-27b1-47ec-a557-0cc01e250e4f</listName>'<query><Query><Where><Eq><FieldRef Name='Project_x0020_Status'/> <Value Type='Choice'>Active</Value></Eq></Where><OrderBy><FieldRef Name='Title' Ascending='TRUE' /></OrderBy></Query></query></GetListItems></soap:Body></soap:Envelope>");
            return soapEnvelop;
        }
    }
