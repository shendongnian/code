    public class MySimpleController
    {
        private GetTestByIdQueryHandler _handler;
        public MySimpleController([FromServices] GetTestByIdQueryHandler handler)
        {
            _handler = handler
        }
        [HttpGet]
        [Route("getTest")]
        public int GetTest([FromServices]GetTestByIdQueryHandler handler,[FromBody]GetTestByIdQuery query)
        {
            return _handler.SomeMethod(query.TestId);   
        }
    }
