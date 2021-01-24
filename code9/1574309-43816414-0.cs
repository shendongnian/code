    [Route("test")]
    public class TestController
    {
            [Route("mult")]
            [HttpGet]
            public int Multiply([FromHeader]string x, [FromHeader]string y)
            {
                
                return Int32.Parse(x) * Int32.Parse(y);
            }
    }
