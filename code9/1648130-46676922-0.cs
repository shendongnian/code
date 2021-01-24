    public class MyControllerController : ApiController {
        public SimpleResponse<DataModel> GET(string _inData) {            
            DataModel data = new DataModel();
                
                try {
                    System.Net.WebClient client = new System.Net.WebClient();
                    String Domain = CallToGetValueFromWebConfig("WEBAPIURL", "value");
                    String theURI = String.Format("{0}api/ApIControllerName?_inData={1}", Domain, _inData);
                    client.BaseAddress = theURI;
                    client.UseDefaultCredentials = true;
                    var json = client.DownloadString(theURI);
                    data = JsonConvert.DeserializeObject<DataModel>(json, new JsonSerializerSettings() {
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    });
                } catch (Exception ex) {
                    EventLogging.AddExceptionEvent(EventLogging.EventID.WebApiDataGet, "Some error text", ex);
                }
            
            return new SimpleResponse<DataModel> { Data = data}; 
        }
    }
    }
