    public class MyController : ApiController
    {
        [HttpGet]
        [Route("api/load-stuff")]
        public Stuff LoadStuff([FromUri]MyRequest request)
        {
            return BackEnd.LoadStuff(request.ToMyPrettyRequest());
        }
    }
    public class MyRequest
    {
        public string request_number { get; set; }
        public string name { get; set; }
        MyPrettyRequest ToMyPrettyRequest()
        {
            return new MyPrettyRequest
            {
                RequestNumber = request_number,
                Name = name,
            };
        }
    }
    public class MyPrettyRequest
    {
        public string RequestNumber { get; set; }
        public string Name { get; set; }
    }
