    public class TestController : ApiController
    {
        [HttpPost]
        public void TakeIt([FromBody]MyObject o){
            Console.Write(o.ToString());
        }
    }
