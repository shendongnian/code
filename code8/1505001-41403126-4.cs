    public class ValuesController: Controller
    {
        public string GetHeaderValue([FromHeader(Name = "device-id")] string id)
        {
            return id;
        }
    }
