    public class TestController : Controller
    {
        [HttpPost]
        public string Send(Data data)
        {
            return data.Content;
        }
    }
    
    public class Data
    {
        public string Content { get; set; }
    }
