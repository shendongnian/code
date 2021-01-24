    public class ValuesController : ApiController
    {
        public HttpResponseMessage Get()
        {
            List<DeviceModels> list = new List<DeviceModels>();
            list.Add(new DeviceModels() { Id = "1", Name = "x1", LocationName = "Floor 2" });
            list.Add(new DeviceModels() { Id = "2", Name = "x2", LocationName = "Floor 2" });
    
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, JsonConvert.SerializeObject(list));
    
            return response;
         }
    }
