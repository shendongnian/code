    [TestClass]
    public class UnitTest3 {
        public async Task GetServicesList() {
            var url = "http://domain.ca/ArcGIS/rest/services/appData?f=json";
            var client = new HttpClient();
            var response = await client.GetAsync(url);
            var model = await response.Content.ReadAsAsync<ServiceResponse>();
            var servicesList = model.services.Select(s => s.name.Replace("appData/", "")).ToArray();
        }
        public class Service {
            public string name { get; set; }
            public string type { get; set; }
        }
        public class ServiceResponse {
            public double currentVersion { get; set; }
            public IList<object> folders { get; set; }
            public IList<Service> services { get; set; }
        }
    }
