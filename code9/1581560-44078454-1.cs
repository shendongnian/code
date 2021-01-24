    public class TestModel
    {
        public bool Sample { get; set; }
    }
    [HttpPost, Route("Test")]
    public IHttpActionResult Test(TestModel model)
    {
        return Ok();
    }
